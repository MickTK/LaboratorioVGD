using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Manager _manager;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        _manager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //TODO: Creare un vettore chiamato "movement" che rappresenta il moviemnto del nemico verso il player
        Vector3 movement = player.transform.position - transform.position;
        movement.Normalize();
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            _manager.UpdateScore();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //memorizza il punteggio del giocatore e torna al menu
            Destroy(other.gameObject);
            _manager.saveData();
            SceneManager.LoadScene(0);
        }
    }
}
