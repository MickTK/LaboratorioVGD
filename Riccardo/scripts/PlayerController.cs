using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float velocity = 10f;
    public float lane = 0f;
    public float xPosition = 0f;
    public float yPosition = 0f;
    private int movement = 0;
    const int quaranta = 40;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }


        if (Input.GetKeyDown("w"))
        {

        }

        if (Input.GetKeyDown("s"))
        {

        }

        if (Input.GetKeyDown("a") && lane > -1)
        {
            lane -= 1;
            xPosition = -1;

            if(movement == 0){
                movement = quaranta;
            } else {
                movement = quaranta - movement;
            }
        }

        if (Input.GetKeyDown("d") && lane < 1)
        {
            lane += 1;
            xPosition = 1;

            if(movement == 0){
                movement = quaranta;
            } else {
                movement = quaranta - movement;
            }
        }


        if(movement != 0){
            movement -= 1;
            Vector3 translator = new Vector3(xPosition * velocity, yPosition * velocity, 0); 
            controller.transform.Translate(translator * Time.deltaTime);
        }
    }
}