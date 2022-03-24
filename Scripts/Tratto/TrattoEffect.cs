using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrattoEffect : MonoBehaviour
{
    GameVariable gameVariable;

    void Start(){
        gameVariable = GetComponent<GameVariable>();
    }

    void Update(){

        for (int i = gameVariable.Tratti.Active.Count - 1; i >= 0; i--)
        {
           
        }
    }

}
