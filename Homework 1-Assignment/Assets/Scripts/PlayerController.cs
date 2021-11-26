using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private CharacterController characterController;


    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();
        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //TODO: Istanziare il prefab "bullet" nella posizione del player.
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            //TODO: Aggiungere una forza di tipo Impulse al bullet per farlo sparare verso il forward del player con una forza di 100.
            b.GetComponent<Rigidbody>().AddForce(transform.forward*100, ForceMode.Impulse);
            //TODO: Distruggere il bullet dopo 3 secondi. Hint: vedere gli overload di Destroy()
            Destroy(b, 3);
        }
    }
}