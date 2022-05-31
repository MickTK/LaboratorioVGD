using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{


    bool waitObs = false;
    int countObstacles = 0;
    ObjectController myController;
    public GameVariable gameVariable;


    // Start is called before the first frame update
    void Start()
    {
        myController= GetComponent<ObjectController>();
        myController.prefOstacoli = Resources.LoadAll<GameObject>("Interactable/Obstacles");
        myController.prefDoni = Resources.LoadAll<GameObject>("Interactable/Collectable/Gifts/Prefabs");
        StartCoroutine("delaySpawn");
        //myController.shop = GameObject.Find("Shop");
        //myController.shop.SetActive(false);
            
    }

    // Update is called once per frame
    void Update()
    {
        if(gameVariable.isGameRunning){ //flag che esegue un check se il gioco è effettivamente in running
            
            if(waitObs){    //utilizzo un flag che aggiorno con una coroutine per aggiungere un ritardo allo spawn degli ostacoli

                StartCoroutine("delayObs");  


                //ogni n file di ostacoli istantanzio una fila differente
                if(countObstacles%gameVariable.giftsSpawnRate==0 && countObstacles!=0){

                    //fila con un gift
                    myController.spawnOstacoli(true); 
                    countObstacles++;  
                   
                } else if (countObstacles%gameVariable.shopSpawnRate==0 && countObstacles!=0){

                    //fila con lo shop
                    myController.spawnOstacoli(false);
                    myController.shop.SetActive(true);
                    countObstacles=0;
                } else {

                    //fila qualsiasi
                    myController.spawnOstacoli(false);
                    countObstacles++;
                }   
                
            }  
            
            myController.moveForward();
            myController.reset();
        }
    }


    IEnumerator delayObs(){
        waitObs=false;
        yield return new WaitForSecondsRealtime(gameVariable.obstacleWaitTime); //posso decidere ogni quanto ritardare lo spawn degli ostacoli tramite questa variabile
        waitObs=true;
    }

  
    IEnumerator delaySpawn(){
        //coroutine di delay per il primo spawn degli ostacoli
        yield return new WaitForSecondsRealtime(2); 
        waitObs=true;

    }
    
 

}
