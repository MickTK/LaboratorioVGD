using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameVariable gameVariable;
    public GameObject UI;
    public GameObject EndGame;

    void Start(){
        
        gameVariable = GetComponent<GameVariable>();
        //TODO LOAD STUFF
    }

    void Update(){

        if(gameVariable.Tratti.Active.Count > 6){

            //TODO YOU WIN
            //TODO CALCOLARE IL PUNTEGGIO FINALE

            //! yspeed * monete * vite * viteoro*2 * difficolta
        }

        if(gameVariable.vite < 0){

            UI.SetActive(false);
            EndGame.SetActive(true);
        }
    }
}
