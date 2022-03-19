using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{     
    
    public enum Oggetti //enum che permette di ridurre i magic number e gestire i gruppi di ostacoli
    {  
        MONETA1,
        MONETA2,
        OSTACOLO1,
        OSTACOLO2,  
        OSTACOLO3,
        OSTACOLO4,
        OSTACOLO5,
        OSTACOLO6
       
    }

    public enum Poteri  //enu m che permette di dividere i possibili power up da implementare a livello visivo
    {
        POTERE1,
        POTERE2,
        POTERE3

    }



    private static float speed = 15f;   //velocità di spostamento di tutti gli oggetti di gioco

    /*creo un vettore per ogni tipo di prefab istanziabile*/    
    static GameObject[] prefGruppi;     
    static GameObject[] prefPoteri;     

    /*Creo una lista per ogni tipo di oggetto attualmente presente nella scena*/
    static List <GameObject> listElementi;  
    static List <GameObject> listGruppi;
    static List <GameObject> listPoteri;
    static List <GameObject> listChunk;
    static List <GameObject> listLPlanes;
    static List <GameObject> listRPlanes;
    static List <GameObject> listEnvironment;



    


    void Start(){
        
        /*Carico le cartelle dei prefab negli appositi vettori*/

        //prefGruppi = Resources.LoadAll<GameObject>("Prefabs/Gruppi");
        //prefPoteri = Resources.LoadAll<GameObject>("Prefabs/Poteri");

        listElementi= new List<GameObject>();
        listChunk =new List<GameObject>(GameObject.FindGameObjectsWithTag("Chunk"));
        listLPlanes = new List<GameObject>(GameObject.FindGameObjectsWithTag("LPlane"));
        listRPlanes = new List<GameObject>(GameObject.FindGameObjectsWithTag("RPlane"));
        listEnvironment= new List<GameObject>(GameObject.FindGameObjectsWithTag("Environment"));

               
    }

    public static Vector3 randCoord(){

        /*creo la posizione dell'oggetto da istanziare, con y e z fisse ma x variabile*/
          
        Vector3 randPos;  
        int posX;              
        posX= UnityEngine.Random.Range(-1,2)*2; //genero una x casuale tra -2,0 e 2
        return randPos = new Vector3(posX,0,80); 
        

    }

    public static void spawnOstacolo(){
        Vector3 randPos = ObjectController.randCoord();   
        Oggetti what = (Oggetti) UnityEngine.Random.Range(0,8); //creo una variabile casuale tra 0 e 8 che decide il tipo di oggetto da istanziare
           
        switch(what)
            {
                
            case Oggetti.MONETA1:   
            Instantiate(prefGruppi[0], randPos, Quaternion.identity);
            break;

            case Oggetti.MONETA2:
            Instantiate(prefGruppi[1], randPos, Quaternion.identity);
            break;

            case Oggetti.OSTACOLO1 :
            Instantiate(prefGruppi[2], randPos, Quaternion.identity);
            break;

            case Oggetti.OSTACOLO2 :
            Instantiate(prefGruppi[3], randPos, Quaternion.identity);
            break;
                
                
            case Oggetti.OSTACOLO3 :
            Instantiate(prefGruppi[4], randPos, Quaternion.identity);
            break;
                
            case Oggetti.OSTACOLO4 :
            Instantiate(prefGruppi[5], randPos, Quaternion.identity);
            break;
                
            case Oggetti.OSTACOLO5 :
            Instantiate(prefGruppi[6], randPos, Quaternion.identity);
            break;
                
            case Oggetti.OSTACOLO6 :
            Instantiate(prefGruppi[7], randPos, Quaternion.identity);
            break;
                
                
            }
            
           

    }

    public static void spawnPower(){


        Vector3 randPos = ObjectController.randCoord();
        Poteri what = (Poteri) UnityEngine.Random.Range(0,3);

        switch(what){
            case Poteri.POTERE1:
            Instantiate(prefPoteri[0], randPos, Quaternion.identity);
            break;

            case Poteri.POTERE2:
            Instantiate(prefPoteri[1], randPos, Quaternion.identity);
            break;

            case Poteri.POTERE3:
            Instantiate(prefPoteri[2], randPos, Quaternion.identity);
            break;
            
        }
        
        

    }



    public static void moveTerrains(GameObject el){
            
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

    public static void find(){  

        //legge i gruppi, chunk e poteri presenti in gioco attualmente
        //listGruppi= new List<GameObject>(GameObject.FindGameObjectsWithTag("Gruppo"));
        //listPoteri =new List<GameObject>(GameObject.FindGameObjectsWithTag("Potere"));
        

        //ricrea una lista totale di elementi presenti
        
        
        //listElementi= new List<GameObject>(listGruppi);
        //listElementi.AddRange(listPoteri);

        listElementi.RemoveAll(el =>true);
        listElementi.AddRange(listChunk);
        listElementi.AddRange(listLPlanes);
        listElementi.AddRange(listRPlanes);        
        listElementi.AddRange(listEnvironment);

        
    }

    public static void move(){


        ObjectController.find();    

        if(listElementi!=null){
            foreach(GameObject el in listElementi){
                el.transform.Translate(-Vector3.forward *Time.deltaTime* speed);
            }
        }

    }


    public static void moveEnvironment(GameObject el){

        Vector3 position= new Vector3 (el.transform.position.x,el.transform.position.y,90);
        el.transform.position=position;

    }



    public static void reset(){


        ObjectController.find();

        

        if(listElementi!=null){
            foreach(GameObject el in listElementi){
                if(el.transform.position.z<-10){
                    switch(el.tag){

                        case "RPlane":
                        case "LPlane":
                        case "Chunk":
                            ObjectController.moveTerrains(el);
                        break;

                        case "Environment":
                            ObjectController.moveEnvironment(el);
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
