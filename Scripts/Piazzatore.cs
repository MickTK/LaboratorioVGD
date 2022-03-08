using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piazzatore : MonoBehaviour
{
    public PlayerController pc;
    CharacterController ch;
    Vector3 posizioneIniziale;

    public GameObject[] oggetti;
    int step;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
        posizioneIniziale = ch.transform.position;

        step = (int)ch.transform.position.x;
    }


    Vector3 posizione;
    void Update()
    {
        Vector3 movement = new Vector3(-2f, 0, 0) * pc.speed;
        ch.Move(movement * Time.deltaTime);

        // Spawna gli oggetti sulla mappa
        if ((int)ch.transform.position.x != step && Random.Range(0,500) == 0)
        {
            step = (int)ch.transform.position.x;
            // Posizione nuovo oggetto
            posizione = new Vector3(transform.position.x, transform.position.y, Random.Range(0,5)+0.5f);
            // Nuova istanza dell'oggetto
            Instantiate(oggetti[Random.Range(0,oggetti.Length-1)], posizione, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Muro link"))
        {
            ch.enabled = false;
            ch.transform.position = new Vector3(pc.posizioneIniziale.x, posizioneIniziale.y, posizioneIniziale.z);
            ch.enabled = true;
        }*/
    }
}
