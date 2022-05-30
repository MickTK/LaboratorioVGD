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
        myController.prefOstacoli = Resources.LoadAll<GameObject>("Obstacles");
        myController.prefDoni = Resources.LoadAll<GameObject>("Gifts");
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

                /*
                    if(countObstacles!=5&&!=10){
                        myController.spawnOstacoli(false);
                        countObstacles++;
                    }
                    else if(countObstacles==5){  
                        myController.spawnOstacoli(true);                    
                    }
                    else if(countObstacles==10){
                        myController.spawnOstacoli(true);
                        myController.shop.SetActive(true);
                        countObstacles=0;
                    }
                */

                switch (countObstacles)
                {
                    case 5:
                        myController.spawnOstacoli(true); 
                        countObstacles++;        
                    break;
                    case 10:
                        myController.spawnOstacoli(true);
                        myController.shop.SetActive(true);
                        countObstacles=0;
                    break;
                    
                    default:
                        myController.spawnOstacoli(false);
                        countObstacles++;
                        break;
                    
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
