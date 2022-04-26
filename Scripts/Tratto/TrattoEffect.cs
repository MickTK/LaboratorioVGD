using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrattoEffect : MonoBehaviour
{
    GameVariable gameVariable;

    void Start(){

        gameVariable = GetComponent<GameVariable>();
        StartCoroutine(TrattoEffects());    
    }

    IEnumerator TrattoEffects()
    {
        while(true) 
        { 
            if(gameVariable.isGameRunning){
                ApplyEffects();
                Exprire();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void ApplyEffects(){

        foreach (Tratto tratto in gameVariable.Tratti.Active)
        {
            switch (tratto.tipo)
            {

            }
            tratto.durata -= 1;
        }
    }

    void Exprire(){

        for (int i = gameVariable.Tratti.Active.Count - 1; i >= 0; i--)
        {
            if(gameVariable.Tratti.Active[i].durata < 0){

                gameVariable.Tratti.Active.Remove(gameVariable.Tratti.Active[i]);
            }
        }
    }
}
