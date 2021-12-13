using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject bridge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press(){
        //Questo potrebbe tornarvi utile (non per questo homework ma in generale). E' possibile iterare su tutti gli oggetti figli di un GameObject sfruttando la gerarchia che esiste tra i loro Transform.
        foreach(Transform child in bridge.transform){
            BoxCollider bc = child.gameObject.GetComponent<BoxCollider>();
            Material mat = child.gameObject.GetComponent<Renderer>().material;
            bc.isTrigger = !bc.isTrigger;

            if(!bc.isTrigger){
                mat.color = new Color(mat.color.r,mat.color.g,mat.color.b,1);
            }
            else{
                mat.color = new Color(mat.color.r,mat.color.g,mat.color.b,0.5f);;
            }
        }
    }
}
