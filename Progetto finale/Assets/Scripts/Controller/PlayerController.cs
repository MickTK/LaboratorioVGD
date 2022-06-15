using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject gameManager;
    GameVariable gameVariable;
    private CharacterController controller;
    public int lane = 2; // lane attuale, indice per il movimento tra le lanes
    public float xDirection = 0f; // la direzione destra o sinistra verso cui si muove il player
    public float yPosition = 0f;
    private float jumpSpeed = 3.5f;
    private Vector3[] lanes = new Vector3[]{

        new Vector3(-4,0,0), // lane left left
        new Vector3(-2,0,0), // lane left center
        new Vector3(0,0,0), // lane center
        new Vector3(2,0,0), // lane right center
        new Vector3(4,0,0) // lane right right

    };

    /* Animazione */
    private Animator animator;
    public Renderer rend;
    private Material originalMaterial; // Materiale della mesh
    public Material replaceMaterial;   // Materiale di rimpiazzo
    private IEnumerator coroutine;     // Coroutine per il blink

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameVariable = gameManager.GetComponent<GameVariable>();

        /* Animazione */
        animator = GetComponent<Animator>(); // Recupera l'animator
        animator.SetBool("die", false);      // Rimuove il trigger della morte (per sicurezza)
        animator.SetFloat("speed", 10f);     // Aumenta la velocit� del giocatore
        originalMaterial = rend.material;    // Materiale del personaggio
    }

    void Update()
    {

        if (Input.GetKeyDown("w"))
        {
            MoovingUp();
        }

        if (Input.GetKeyDown("s"))
        {
            MoovingDown();
        }

        MoovingVertical();

        if (Input.GetKeyDown("a"))
        {
            MoovingLeft();
        }

        if (Input.GetKeyDown("d"))
        {
            MoovingRight();
        }

        MoovingHorizontal();
    }

    public void MoovingUp(){

        if(gameVariable.isGameRunning && controller.isGrounded){
            
            yPosition = jumpSpeed;

            /* Animazione */
            animator.ResetTrigger("jump");  // Resetta il trigger del salto
            animator.SetTrigger("jump");    // Attiva l'animazione del salto

            FindObjectOfType<AudioManager>().Play("Salto"); // Suono
        }
    }

    public void MoovingDown(){

        if(gameVariable.isGameRunning){

            yPosition -= jumpSpeed;
        }
    }

    public void MoovingLeft(){

        if(gameVariable.isGameRunning && lane > 0){

            lane -= 1;
            xDirection = -1;
        }
    }

    public void MoovingRight(){

        if(gameVariable.isGameRunning && lane < 4){

            lane += 1;
            xDirection = 1;
        }
    }

    void MoovingVertical(){

        Vector3 direction = new Vector3();
        yPosition -= gameVariable.gravity * Time.deltaTime;
        direction.y = yPosition;
        controller.Move(direction * gameVariable.jumpForce * Time.deltaTime);
    }

    void MoovingHorizontal(){
        
        if (xDirection == -1 && controller.transform.position.x > lanes[lane].x)
        {

            Vector3 translator = new Vector3(xDirection * gameVariable.xSpeed, 0, 0);
            controller.transform.Translate(translator * Time.deltaTime);
        }

        if (xDirection == 1 && controller.transform.position.x < lanes[lane].x)
        {

            Vector3 translator = new Vector3(xDirection * gameVariable.xSpeed, 0, 0);
            controller.transform.Translate(translator * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Obstacle" || other.transform.tag == "ObstaclePart")
        {
            Destroy(other.gameObject);

            if (gameVariable.vite > 0 && !gameVariable.invincible)
            {
                gameVariable.invincible = true;
                /* Animazione */
                coroutine = Blink(5, 0.1f);
                StartCoroutine(coroutine);

                FindObjectOfType<AudioManager>().Play("Bonk"); // Suono

                gameVariable.vite -= 1;
            }
        }

        if (other.transform.tag == "Coin")
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Moneta"); // Suono
            int MoneyValue = other.GetComponent<MoneyValue>().value;
            gameVariable.monete += MoneyValue * gameVariable.moltiplicatoreMonete;
        }

        if (other.transform.tag == "Gift")
        {

            Destroy(other.gameObject);
            gameVariable.doni += 1;

            FindObjectOfType<AudioManager>().Play("Oggetto"); // Suono
        }

        if (other.transform.tag == "Shop")
        {
            gameVariable.openShop = true;
        }
    }

    public void Die()
    {
        /* Animazione */
        animator.SetBool("die", true); // Attiva l'animazione della morte del giocatore
    }

    /* Effetto danno */
    private IEnumerator Blink(int blinks, float time)
    {
        for (int i = 0; i < blinks; i++)
        {
            rend.material = replaceMaterial;       // Trasparente
            yield return new WaitForSeconds(time);
            rend.material = originalMaterial;      // Visibile
            yield return new WaitForSeconds(time);
        }
        gameVariable.invincible = false;
        StopCoroutine(coroutine);                  // Termina la coroutine
    }
}