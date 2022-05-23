using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrattoHandler : MonoBehaviour
{

    public GameObject trattoUI;
    public TrattoDisplayer tratto1;
    public TrattoDisplayer tratto2;
    public TrattoDisplayer tratto3;
    public Button exitButton;
    GameVariable gameVariable;

    void Start(){

        gameVariable = GetComponent<GameVariable>();

        Button btn1 = tratto1.GetComponent<Button>(); 
        btn1.onClick.AddListener(delegate{ Click(tratto1.Tratto); });

        Button btn2 = tratto2.GetComponent<Button>();
        btn2.onClick.AddListener(delegate{ Click(tratto2.Tratto); });
                
        Button btn3 = tratto3.GetComponent<Button>();
        btn3.onClick.AddListener(delegate{ Click(tratto3.Tratto); });

        Button exit = exitButton.GetComponent<Button>();
        exit.onClick.AddListener(Exit);

        trattoUI.SetActive(false);
    }

    void Click(Tratto tratto){

        trattoUI.SetActive(false);
        gameVariable.Tratti.Active.Add(tratto);
        gameVariable.Tratti.Remove(tratto);
        gameVariable.isGameRunning = true;
    }

    void Exit(){
        gameVariable.isGameRunning = true;
        trattoUI.SetActive(false);
    }

    void Update(){

        if (gameVariable.doni == 4 || Input.GetKeyDown("x"))
        {
            StartCoroutine(OpenTratto());
            gameVariable.doni = 0;
            gameVariable.ySpeed += 5;
            gameVariable.xSpeed += 1;
        }
    }
    
    IEnumerator OpenTratto(){

        yield return new WaitForSeconds(1f);

        gameVariable.isGameRunning = false;
        trattoUI.SetActive(true);
        tratto1.Tratto = gameVariable.Tratti.Draw();
        tratto2.Tratto = gameVariable.Tratti.Draw();
        tratto3.Tratto = gameVariable.Tratti.Draw();
    }
}
