using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{


    bool waitObs = true;
    int countObstacles = 0;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if(waitObs){

            StartCoroutine("delayObs");  

            if(countObstacles<5){
                ObjectController.spawnOstacolo();
                countObstacles++;
            }
            else{  
                ObjectController.spawnPower();
                countObstacles=0;
            }
                  
            
        }

        ObjectController.move();
        ObjectController.delete();

    }


    IEnumerator delayObs(){
        waitObs=false;
        yield return new WaitForSecondsRealtime(2);
        waitObs=true;
    }

  
    
 

}
