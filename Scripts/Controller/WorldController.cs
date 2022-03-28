using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{


    bool waitObs = false;
    int countObstacles = 0;
    ObjectController myController;
    


    // Start is called before the first frame update
    void Start()
    {
        myController= GetComponent<ObjectController>();
        myController.prefOstacoli = Resources.LoadAll<GameObject>("Obstacles");
        StartCoroutine("delaySpawn");
    }

    // Update is called once per frame
    void Update()
    {
       
        if(waitObs){

            StartCoroutine("delayObs");  

            if(countObstacles<5){
                myController.spawnOstacoli();
                countObstacles++;
            }
            else{  
                //ObjectController.spawnPower();
                countObstacles=0;
            } 
                  
            
        }

        myController.moveForward();
        myController.reset();

    }


    IEnumerator delayObs(){
        waitObs=false;
        yield return new WaitForSecondsRealtime(2);
        waitObs=true;
    }

  
    IEnumerator delaySpawn(){

        yield return new WaitForSecondsRealtime(2);
        waitObs=true;

    }
    
 

}
