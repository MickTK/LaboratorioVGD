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

    /* Animazione */
    private Animator animator;
    public Renderer rend;
    private Material originalMaterial; // Materiale della mesh
    public Material replaceMaterial;   // Materiale di rimpiazzo
    private IEnumerator coroutine;     // Coroutine per il blink

    private Vector3[] lanes = new Vector3[]{

        new Vector3(-4,0,0), // lane left left
        new Vector3(-2,0,0), // lane left center
        new Vector3(0,0,0), // lane center
        new Vector3(2,0,0), // lane right center
        new Vector3(4,0,0) // lane right right

    };

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameVariable = gameManager.GetComponent<GameVariable>();

        /* Animazione */
        animator = GetComponent<Animator>(); // Recupera l'animator
        animator.SetBool("die", false);      // Rimuove il trigger della morte (per sicurezza)
        animator.SetFloat("speed", 10f);     // Aumenta la velocità del giocatore
        originalMaterial = rend.material;    // Materiale del personaggio
    }

    void Update()
    {
        if (gameVariable.isGameRunning)
        {
            Mooving();
        }

    }

    void Mooving()
    {

        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }


        if (Input.GetKeyDown("w") && controller.isGrounded)
        {
            yPosition = jumpSpeed;

            /* Animazione */
            animator.ResetTrigger("jump");  // Resetta il trigger del salto
            animator.SetTrigger("jump");    // Attiva l'animazione del salto

            FindObjectOfType<AudioManager>().Play("Salto"); // Suono
        }

        if (Input.GetKeyDown("s"))
        {
            yPosition -= jumpSpeed;
        }

        Vector3 direction = new Vector3();
        yPosition -= gameVariable.gravity * Time.deltaTime;
        direction.y = yPosition;
        controller.Move(direction * gameVariable.jumpForce * Time.deltaTime);

        if (Input.GetKeyDown("a") && lane > 0)
        {
            lane -= 1;
            xDirection = -1;
        }

        if (Input.GetKeyDown("d") && lane < 4)
        {
            lane += 1;
            xDirection = 1;
        }

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

        if (other.transform.tag == "Obstacle")
        {
            Destroy(other.gameObject);

            if (gameVariable.vite != 0)
            {

                /* Animazione */
                coroutine = Blink(5, 0.1f);
                StartCoroutine(coroutine);

                FindObjectOfType<AudioManager>().Play("Bonk"); // Suono

                gameVariable.vite -= 1;

            }
            else
            {

                //TODO END GAME

                /* Animazione */
                animator.SetBool("die", true); // Attiva l'animazione della morte del giocatore

                FindObjectOfType<AudioManager>().Play("Bonk"); // Suono
            }
        }

        if (other.transform.tag == "Coin")
        {
            FindObjectOfType<AudioManager>().Play("Moneta"); // Suono
            int MoneyValue = other.GetComponent<MoneyValue>().value;
            Destroy(other.gameObject);
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

            Destroy(other.gameObject);
            gameVariable.openShop = true;
        }
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
        StopCoroutine(coroutine);                  // Termina la coroutine
    }
}