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
        if(gameVariable.isGameRunning){
            
            if(waitObs){

                StartCoroutine("delayObs");  


            
                if(countObstacles%gameVariable.giftsSpawnRate==0 && countObstacles!=0){

                    myController.spawnOstacoli(true); 
                    countObstacles++;  
                   
                } else if (countObstacles%gameVariable.shopSpawnRate==0 && countObstacles!=0){

                    myController.spawnOstacoli(false);
                    myController.shop.SetActive(true);
                    countObstacles=0;
                } else {

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
        yield return new WaitForSecondsRealtime(gameVariable.obstacleWaitTime);
        waitObs=true;
    }

  
    IEnumerator delaySpawn(){

        yield return new WaitForSecondsRealtime(2);
        waitObs=true;

    }
    
 

}
