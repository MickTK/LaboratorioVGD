using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{     
    
    public enum Oggetti
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

    public enum Poteri
    {
        POTERE1,
        POTERE2,
        POTERE3

    }



    private static float speed = 15f;
    static GameObject[] prefTerreno;
    static GameObject[] prefGruppi;
    static GameObject[] prefPoteri;
    static List <GameObject> listElementi;
    static List <GameObject> listGruppi;
    static List <GameObject> listPoteri;
    static List <GameObject> listTerreno;



    void Start(){
        
        prefTerreno = Resources.LoadAll<GameObject>("Prefabs/Terreno");
        prefGruppi = Resources.LoadAll<GameObject>("Prefabs/Gruppi");
        prefPoteri = Resources.LoadAll<GameObject>("Prefabs/Poteri");

               
    }



    public static void spawnOstacolo(){

        int posX; 
        Vector3 vettPos;        
        Oggetti what = (Oggetti) UnityEngine.Random.Range(0,8);
        posX= UnityEngine.Random.Range(-1,2)*2;
        vettPos = new Vector3(posX,0,80); 

                
           
        switch(what)
            {
                
            case Oggetti.MONETA1:   
            Instantiate(prefGruppi[0], vettPos, Quaternion.identity);
            break;

            case Oggetti.MONETA2:
            Instantiate(prefGruppi[1], vettPos, Quaternion.identity);
            break;

            case Oggetti.OSTACOLO1 :
            Instantiate(prefGruppi[2], vettPos, Quaternion.identity);
            break;

            case Oggetti.OSTACOLO2 :
            Instantiate(prefGruppi[3], vettPos, Quaternion.identity);
            break;
                
                
            case Oggetti.OSTACOLO3 :
            Instantiate(prefGruppi[4], vettPos, Quaternion.identity);
            break;
                
            case Oggetti.OSTACOLO4 :
            Instantiate(prefGruppi[5], vettPos, Quaternion.identity);
            break;
                
            case Oggetti.OSTACOLO5 :
            Instantiate(prefGruppi[6], vettPos, Quaternion.identity);
            break;
                
            case Oggetti.OSTACOLO6 :
            Instantiate(prefGruppi[7], vettPos, Quaternion.identity);
            break;
                
                
            }
            
           

    }

    public static void spawnPower(){
        int posX; 
        Vector3 vettPos;        
        Poteri what = (Poteri) UnityEngine.Random.Range(0,3);
        posX= UnityEngine.Random.Range(-1,2)*2;
        vettPos = new Vector3(posX,1,80); 

        switch(what){
            case Poteri.POTERE1:
            Instantiate(prefPoteri[0], vettPos, Quaternion.identity);
            break;

            case Poteri.POTERE2:
            Instantiate(prefPoteri[1], vettPos, Quaternion.identity);
            break;

            case Poteri.POTERE3:
            Instantiate(prefPoteri[2], vettPos, Quaternion.identity);
            break;
            
        }
        
        

    }



    public static void movePlane(GameObject chunk){
            
            Vector3 vettPos;        
            float max=0;
            foreach(GameObject p in listTerreno){
                if(p.transform.position.z>max)
                    max=p.transform.position.z;

            }
            max+=10;
            
            vettPos = new Vector3(0,0,max); 
            chunk.transform.position=vettPos;
           

        

    }

    public static void find(){  

        //legge i gruppi, chunk e poteri presenti in gioco attualmente
        listGruppi= new List<GameObject>(GameObject.FindGameObjectsWithTag("Gruppo")); 
        listTerreno =new List<GameObject>(GameObject.FindGameObjectsWithTag("Plane"));
        listPoteri =new List<GameObject>(GameObject.FindGameObjectsWithTag("Potere"));

        //ricrea una lista totale di elementi presenti
        listElementi= new List<GameObject>(listGruppi);
        listElementi.AddRange(listTerreno);
        listElementi.AddRange(listPoteri);
    }

    public static void move(){


        ObjectController.find();    

        if(listElementi!=null){
            foreach(GameObject ogg in listElementi){
                ogg.transform.Translate(-Vector3.forward *Time.deltaTime* speed);
            }
        }

    }

    public static void delete(){


        ObjectController.find();

    

        if(listElementi!=null){
            foreach(GameObject ogg in listElementi){
                if(ogg.transform.position.z<-10){
                    if(ogg.tag=="Plane"){
                        ObjectController.movePlane(ogg);
                    }
                    else{
                        Destroy(ogg);
                    }
                    
                }
            }
        }

    }
    
    
}
