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

    void ClickOne(){
        trattoUI.SetActive(false);
        gameVariable.Tratti.Active.Add(tratto1.Tratto);
        gameVariable.isGameRunning = true;
	}

    void ClickTwo(){
        trattoUI.SetActive(false);
        gameVariable.Tratti.Active.Add(tratto2.Tratto);
        gameVariable.isGameRunning = true;
	}

    void ClickThree(){
        trattoUI.SetActive(false);
        gameVariable.Tratti.Active.Add(tratto3.Tratto);
        gameVariable.isGameRunning = true;
	}

    void Start(){

        gameVariable = GetComponent<GameVariable>();

        Button btn1 = tratto1.GetComponent<Button>(); 
        btn1.onClick.AddListener(ClickOne);

        Button btn2 = tratto2.GetComponent<Button>();
        btn2.onClick.AddListener(ClickTwo);
                
        Button btn3 = tratto3.GetComponent<Button>();
        btn3.onClick.AddListener(ClickThree);

        Button exit = exitButton.GetComponent<Button>();
        exit.onClick.AddListener(Exit);

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

    void Exit(){
        gameVariable.isGameRunning = true;
        trattoUI.SetActive(false);
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
