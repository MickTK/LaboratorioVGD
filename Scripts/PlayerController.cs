using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    CharacterController ch;
    public float speed = 5;
    public float jumpSpeed = 4;
    private const float gravity = 30; // Default: 9.81f
    private float vspeed = 0;

    // Punteggio
    int step;              // Verifica se la posizione del personaggio è cambiata
    int punti = 0;         // Punti correnti
    public Text puntiText; // Mostra i punti a schermo
    int moltiplicatorePunteggio;

    // Monete
    int monete = 0;         // Monete ottenute
    public Text moneteText; // Mostra le monete a schermo

    // Posizione di partenza del giocatore nella mappa
    public Vector3 posizioneIniziale;

    void Start()
    {
        ch = GetComponent<CharacterController>();

        // Inizializza i valori dell'HUD
        puntiText.text = "Punti: " + punti.ToString();
        moneteText.text = "Monete: " + monete.ToString();

        // Inizializza la posizione del giocatore
        posizioneIniziale = ch.transform.position;
        step = (int) ch.transform.position.x;
        moltiplicatorePunteggio = 1;
    }

    void Update()
    {
        /* Movimento oggetto */
        float horMov = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(-2f, 0, horMov*2) * speed;
        horMov = 0;
        //ch.Move(movement * Time.deltaTime);

        if ((int)ch.transform.position.x != step)
        {
            step = (int)ch.transform.position.x;
            punti += moltiplicatorePunteggio;
            puntiText.text = "Punteggio: " + punti.ToString();
        }

        /* Se l'oggetto si trova a terra */
        if (ch.isGrounded)
        {
            /* Legge l'input per il salto (barra spaziatrice) */
            float jump = Input.GetAxis("Jump") * jumpSpeed;
            vspeed = jump;
        }
        else
        {
            /* Aggiorna la posizione sull'asse y dell'oggetto in seguito al salto */
            vspeed -= gravity * Time.deltaTime;
            movement.y = vspeed;
        }
        ch.Move(movement * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        /* In caso di collisione con un oggetto avente tag "Collectible" */
        if(other.CompareTag("Moneta"))
        {
            Destroy(other.gameObject);

            monete++;
            moneteText.text = "Monete: " + monete.ToString();
        }
        // Riporta il giocatore all'inizio della mappa
        /*if (other.CompareTag("Muro link"))
        {
            ch.enabled = false;
            ch.transform.position = new Vector3(posizioneIniziale.x, posizioneIniziale.y, transform.position.z);
            ch.enabled = true;
        }*/
        // Il giocatore ottiene un boost alla velocità
        if (other.CompareTag("Boost"))
        {
            Destroy(other.gameObject);
            speed = speed * 2; // Nuova velocità
            moltiplicatorePunteggio = 2;
            // Timer per il boost
            coroutine = Booster(10f);
            StartCoroutine(coroutine);
        }
        if (other.CompareTag("Ostacolo"))
        {
            Application.Quit();
        }
    }

    private IEnumerator coroutine;
    // Boost timer
    private IEnumerator Booster(float t)
    {
        yield return new WaitForSeconds(t);
        speed = speed / 2;
        moltiplicatorePunteggio = 1;
        StopCoroutine(coroutine);
    }
}
