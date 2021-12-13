using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private bool isShooting = false;
    private bool coroutineIsRunning = false;
    private float fireRatio = 1f;
    private float velocity = 0.0f;
    private Animator animator;
    public TextMeshProUGUI lifeText;

    public GameObject laserPrefab;

    bool isImmune = false;

    private int life = 10;
    // Start is called before the first frame update
    void Start()
    {
        lifeText.SetText(life.ToString());
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //TODO: Scrivere il codice per il movimento del personaggio tramite character controller. La variabile velocity aumenta di 0.3f per ogni secondo in cui l'input utente assume valori positivi e diminuisce di 2.0f altrimenti.
        //La variabile velocity deve sempre essere compresa tra 0.0f e 1.0f. Impostare i parametri velocity e turn dell'animator. 
        
        controller.SimpleMove(transform.forward * velocity * 5.0f);
        transform.Rotate(0, horizontal * 90 * Time.deltaTime, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            //TODO: Lanciare la coroutine ShootCooldown() se e solo se coroutineIsRunning è false, isShooting è false e velocity è minore o uguale a 0.1.

        }
    }

    /*TODO: Inserire il tipo di ritorno corretto*/ void ShootCooldown()
    {
        //TODO: Questa coroutine deve impostare a true la variabile coroutineIsRunning, attivare il paramentro shoot dell'animator e impostare isShooting a true. una volta aspettati "fireRatio" secondi,
        //coroutineIsRunning deve essere impostata a false. 
    }

    void Shoot()
    {
        //TODO: Sparare il raggio ray. Se il raggio colpisce un oggetto con tag "Enemy" allora deve essere richiamato il metodo TakeDamage(1) dello script EnemyController (attaccato all'oggetto colpito).
        //Se invece il raggio colpisce un oggetto con tag "Button" allora deve essere richiamato il metodo Press() dello script ButtonBehavior (attaccato all'oggetto colpito).
        Ray ray = new Ray(transform.position + new Vector3(0,0.6f,0), transform.forward);

    }

    IEnumerator Immunity(){
        yield return new WaitForSeconds(1.5f);
        isImmune = false;
    }

    public void TakeDamage(int damage)
    {   
        if(!isImmune){
            isImmune = true;
            life -= damage;
            lifeText.SetText(life.ToString());
            if (life <= 0)
            {
                SceneManager.LoadScene(0);
            }
            //TODO: Lanciare la coroutine Immunity()
        }

    }

    void FixedUpdate()
    {
        if (isShooting)
        {
            Shoot();
            isShooting = false;

        }

    }
}
