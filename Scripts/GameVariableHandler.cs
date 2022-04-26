using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVariableHandler : MonoBehaviour
{
    //todo COMPLETA STA ROBA, BISUALIZZA LE ROBE
    GameVariable gameVariable;
    public Image diceBar;
    
    void Start()
    {
        gameVariable = GetComponent<GameVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        diceBar.rectTransform.sizeDelta = new Vector2(gameVariable.doni * 30f, 20f);
        //diceBar.rectTransform.position = new Vector2(60f + (15 * gameVariable.doni), 250f);
    }
}
