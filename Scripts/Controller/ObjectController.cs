using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{     
    
    public GameVariable gameVariable;
    /*creo un vettore per ogni tipo di prefab istanziabile*/    
    public GameObject[] prefOstacoli;     
    public GameObject[] prefDoni;     
    byte nCorsieOccupabili = 3;

    /*Creo una lista per ogni tipo di oggetto attualmente presente nella scena*/
    List <GameObject> listElementi = new List<GameObject>();
    List <GameObject> listChunk = new List<GameObject>();
    List <GameObject> listLPlanes = new List<GameObject>();
    List <GameObject> listRPlanes = new List<GameObject>();
    List <GameObject> listEnvironment = new List<GameObject>();

    public GameObject shop;
  
    public void Start(){

        listChunk.AddRange(GameObject.FindGameObjectsWithTag("Chunk"));
        listLPlanes.AddRange (GameObject.FindGameObjectsWithTag("LPlane"));
        listRPlanes.AddRange (GameObject.FindGameObjectsWithTag("RPlane"));
        listEnvironment.AddRange (GameObject.FindGameObjectsWithTag("Environment"));     
    }

    public Vector3 randCoord(){

        /*creo la posizione dell'oggetto da istanziare, con y e z fisse ma x variabile*/ 
        int posX, posZ;              
        posX= UnityEngine.Random.Range(-2,3)*2; //genero una x casuale tra -2,0 e 2
        posZ= UnityEngine.Random.Range(-2,3)*2;
        posZ+=80; 
        return new Vector3(posX,0,posZ); 
    }

    public void spawnOstacoli(bool power){

        int numGenForEachPrefab;
        List <Vector3> posOccupate = new List<Vector3>();        
        Vector3 randPos = randCoord(); 

        if(power){

            numGenForEachPrefab = UnityEngine.Random.Range(0,prefDoni.Length); 
            posOccupate.Add(randPos);
            randPos.y=0.5f;
            Instantiate(prefDoni[numGenForEachPrefab], randPos, Quaternion.identity);
            
            
        }else{

             
            numGenForEachPrefab = UnityEngine.Random.Range(0,prefOstacoli.Length); 
            posOccupate.Add(randPos);
            Instantiate(prefOstacoli[numGenForEachPrefab], randPos, Quaternion.identity);

            
        }

        for (int i = 0; i < nCorsieOccupabili; i++)
            {
                numGenForEachPrefab = UnityEngine.Random.Range(0,prefOstacoli.Length);
                int prob= UnityEngine.Random.Range(0,101);

                if(prob<80){
                    do{
                        randPos = randCoord();
                        }
                    while(posOccupate.Contains(randPos));
                    
                    Instantiate(prefOstacoli[numGenForEachPrefab], randPos, Quaternion.identity);
                    posOccupate.Add(randPos);
                }
            }     
    }
    
    public void find(){  
        listElementi.Clear();

        //elementi generabili
        listElementi.AddRange(GameObject.FindGameObjectsWithTag("Obstacle"));
        listElementi.AddRange(GameObject.FindGameObjectsWithTag("Coin"));
        

        //elementi fissi
        listElementi.AddRange(listChunk);
        listElementi.AddRange(listLPlanes);
        listElementi.AddRange(listRPlanes);        
        listElementi.AddRange(listEnvironment);

        if(shop.activeSelf){
            listElementi.Add(shop);
        }
            
        
    }
    public void moveForward(){


        find();    

        if(listElementi!=null){
            foreach(GameObject el in listElementi){
                el.transform.Translate(-Vector3.forward *Time.deltaTime* gameVariable.ySpeed);
            }
        }

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

                        case "Shop":
                            resetShop(el);
                        break;

                        default:
                            Destroy(el);
                        break;

                    }
                }
            }
        }

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
    public void resetEnv(GameObject el){
        Vector3 position;
        if(GameObject.Find("Shop")==null){
            position= new Vector3 (el.transform.position.x,el.transform.position.y,90);
           
        }else{

            position= new Vector3 (el.transform.position.x,el.transform.position.y,105);
        }
        el.transform.position=position;
    }
    public void resetShop(GameObject el){
        
        Vector3 position= new Vector3 (el.transform.position.x,el.transform.position.y,100);
        el.transform.position=position;
        el.SetActive(false);
    }
}
