using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameVariable gameVariable;
    public GameObject UI;
    public GameObject endGame;
    public GameObject pauseMenu;
    public Text punteggio;
    private IEnumerator coroutine;

    void Start(){
        
        gameVariable = GetComponent<GameVariable>();
        //TODO LOAD STUFF
    }

    public void OpenPause(){
        gameVariable.isGameRunning = false;
        UI.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ClosePause(){
        gameVariable.isGameRunning = true;
        UI.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void Update(){

        if(gameVariable.vite == 0 || gameVariable.Tratti.Active.Count > 7){ // se hai più di 7 tratti o non hai vita 

            gameVariable.isGameRunning = false;
            UI.SetActive(false);

            coroutine = OpenMenuEnding(2.0f);
            StartCoroutine(coroutine);

        }
    }

    private IEnumerator OpenMenuEnding(float waitTime)
    {
        while (true)
        {

            int num = (int) (gameVariable.ySpeed * ((gameVariable.monete / 5) + 1) * (gameVariable.vite + 1) * 
            ((gameVariable.buyedItems/2) + 1) * (gameVariable.viteOro*2 + 1) * (gameVariable.difficolta + 1) * 
            (gameVariable.Tratti.Active.Count + 1)) / 10;
            //TODO SERIALIZE THIS

            endGame.SetActive(true);

            punteggio.text = "Punteggio: " + num.ToString();

            yield return new WaitForSeconds(waitTime);
        }
    }
}
