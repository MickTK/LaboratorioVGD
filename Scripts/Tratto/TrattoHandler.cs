using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrattoHandler : MonoBehaviour
{

    public GameObject permanentiUI;
    public TrattoDisplayer tratto1;
    public TrattoDisplayer tratto2;
    public TrattoDisplayer tratto3;
    GameVariable gameVariable;

    void ClickOne(){
        permanentiUI.SetActive(false);
        gameVariable.Tratti.Active.Add(tratto1.Tratto);
	}

    void ClickTwo(){
        permanentiUI.SetActive(false);
        gameVariable.Tratti.Active.Add(tratto2.Tratto);
	}

    void ClickThree(){
        permanentiUI.SetActive(false);
        gameVariable.Tratti.Active.Add(tratto3.Tratto);
	}

    void Start(){

        gameVariable = GetComponent<GameVariable>();

        Button btn1 = tratto1.GetComponent<Button>();
        btn1.onClick.AddListener(ClickOne);

        Button btn2 = tratto2.GetComponent<Button>();
        btn2.onClick.AddListener(ClickTwo);
                
        Button btn3 = tratto3.GetComponent<Button>();
        btn3.onClick.AddListener(ClickThree);

        permanentiUI.SetActive(false);
    }

    void Update(){

        if (gameVariable.doni == 4 || Input.GetKeyDown("x"))
        {
            StartCoroutine(OpenTratto());
            gameVariable.doni = 0;
        }
    }

    IEnumerator OpenTratto(){

        yield return new WaitForSeconds(1f);

        permanentiUI.SetActive(true);
        tratto1.Tratto = gameVariable.Tratti.Draw();
        tratto2.Tratto = gameVariable.Tratti.Draw();
        tratto3.Tratto = gameVariable.Tratti.Draw();
    }
}
