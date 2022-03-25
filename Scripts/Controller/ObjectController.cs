using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{     
    
    
    private  float speed = 15f;   //velocità di spostamento di tutti gli oggetti di gioco

    /*creo un vettore per ogni tipo di prefab istanziabile*/    
    public GameObject[] prefOstacoli;     
    GameObject[] prefPoteri;     

    /*Creo una lista per ogni tipo di oggetto attualmente presente nella scena*/
    List <GameObject> listElementi = new List<GameObject>();
    List <GameObject> listOstacoli = new List<GameObject>();
    List <GameObject> listPoteri = new List<GameObject>();
    List <GameObject> listChunk = new List<GameObject>();
    List <GameObject> listLPlanes = new List<GameObject>();
    List <GameObject> listRPlanes = new List<GameObject>();
    List <GameObject> listEnvironment = new List<GameObject>();
    int howMany;


    


    public void Start(){
        
        /*Carico le cartelle dei prefab negli appositi vettori*/

        
        howMany=prefOstacoli.Length;

        //Debug.Log("numero prefab: "+howMany);
        //prefPoteri = Resources.LoadAll<GameObject>("Prefabs/Poteri");
        //listElementi 
        //listOstacoli 
        listChunk.AddRange(GameObject.FindGameObjectsWithTag("Chunk"));
        listLPlanes.AddRange (GameObject.FindGameObjectsWithTag("LPlane"));
        listRPlanes.AddRange (GameObject.FindGameObjectsWithTag("RPlane"));
        listEnvironment.AddRange (GameObject.FindGameObjectsWithTag("Environment"));

               
    }

    public Vector3 randCoord(){

        /*creo la posizione dell'oggetto da istanziare, con y e z fisse ma x variabile*/
          
        Vector3 randPos;  
        int posX;              
        posX= UnityEngine.Random.Range(-2,3)*2; //genero una x casuale tra -2,0 e 2
        return randPos = new Vector3(posX,0,80); 
        

    }

    public void spawnCoord(Vector3 coordinate){
        Vector3 randPos = randCoord();   
        int what = UnityEngine.Random.Range(0,howMany); 
        if(coordinate!=randPos){
            Instantiate(prefOstacoli[what], randPos, Quaternion.identity);
        }
        else{
            spawnCoord(coordinate);
        }
        
    }

    public void spawnOstacolo(){
        Vector3 randPos = randCoord();   
        int what = UnityEngine.Random.Range(0,howMany); 
        Instantiate(prefOstacoli[what], randPos, Quaternion.identity);

        int prob= UnityEngine.Random.Range(0,101);
        if(prob<80){
            spawnCoord(randPos);
        }
           
                   
    }

    public void spawnPower(){


        Vector3 randPos = randCoord();
        int what = UnityEngine.Random.Range(0,prefPoteri.Length+1);
        Instantiate(prefPoteri[what], randPos, Quaternion.identity);


    }

    public void resetTerrains(GameObject el){
            
        Vector3 posIniz;
        float max=0;
        float posX=0;
        float posZ=0;

        switch(el.tag){

            case "Chunk":
                foreach(GameObject p in listChunk){
                    if(p.transform.position.z>max)
                        max=p.transform.position.z;
                        posX=0;
                        
                }
            break;

            case "LPlane":
                foreach(GameObject p in listLPlanes){
                    if(p.transform.position.z>max){
                        max=p.transform.position.z;
                        posX=-15;
                    }
                }
            break;

            case "RPlane":
                foreach(GameObject p in listRPlanes){
                     if(p.transform.position.z>max){
                        max=p.transform.position.z;
                        posX=15;
                    }
                }
            break;


        }

        posZ=max+10;
        posIniz = new Vector3(posX,0,posZ); 
        el.transform.position=posIniz;
           

        

    }

    public void find(){  

      
        listOstacoli.RemoveAll(el=>true);
        listOstacoli.AddRange(GameObject.FindGameObjectsWithTag("Obstacle"));

        listElementi.RemoveAll(el =>true);
        listElementi.AddRange(listOstacoli);
        listElementi.AddRange(listChunk);
        listElementi.AddRange(listLPlanes);
        listElementi.AddRange(listRPlanes);        
        listElementi.AddRange(listEnvironment);

        
    }

    public void moveForward(){


        find();    

        if(listElementi!=null){
            foreach(GameObject el in listElementi){
                el.transform.Translate(-Vector3.forward *Time.deltaTime* speed);
            }
        }

    }


    public static void resetEnv(GameObject el){

        Vector3 position= new Vector3 (el.transform.position.x,el.transform.position.y,90);
        el.transform.position=position;

    }

    public void reset(){
        find();
        if(listElementi!=null){
            foreach(GameObject el in listElementi){
                if(el.transform.position.z<-10){
                    switch(el.tag){

                        case "RPlane":
                        case "LPlane":
                        case "Chunk":
                            resetTerrains(el);
                        break;

                        case "Environment":
                            resetEnv(el);
                        break;

                        default:
                            Destroy(el);
                        break;

                    }
                }
            }
        }

    }
    
    
}
