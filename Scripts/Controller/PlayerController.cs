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

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameVariable = gameManager.GetComponent<GameVariable>();
    }

    void Update()
    {
        if(gameVariable.isGameRunning){
            Mooving();
        }
    }

    void Mooving(){

        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }


        if (Input.GetKeyDown("w") && controller.isGrounded)
        {
            yPosition = jumpSpeed;
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

        if(xDirection == -1 && controller.transform.position.x > lanes[lane].x){

            Vector3 translator = new Vector3(xDirection * gameVariable.xSpeed, 0, 0); 
            controller.transform.Translate(translator * Time.deltaTime);
        }

        if(xDirection == 1 && controller.transform.position.x < lanes[lane].x){

            Vector3 translator = new Vector3(xDirection * gameVariable.xSpeed, 0, 0); 
            controller.transform.Translate(translator * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.tag == "Obstacle")
        {
            Destroy(other.gameObject);

            if(gameVariable.vite != 0){

                gameVariable.vite -= 1;

            } else {

                //TODO END GAME
            }
        }

        if(other.transform.tag == "Coin"){

            MoneyValue component = other.GetComponent<MoneyValue>();
            Destroy(other.gameObject);
            gameVariable.monete += component.Value;
        }

        if(other.transform.tag == "Gift"){

            Destroy(other.gameObject);
            gameVariable.doni += 1;
        }
        
        if(other.transform.tag == "Shop"){
            
            Destroy(other.gameObject);
            gameVariable.openShop = true;
        }
    }
}