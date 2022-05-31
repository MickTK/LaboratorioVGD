using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrattoEffect : MonoBehaviour
{
    GameVariable gameVariable;
    private int mulMoneteSadico = 1;
    private int holderMoneteInvestimento = 1;
    private bool altissimoFlag = false;
    private bool renditaFlag = false;

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
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void ApplyEffects(){ //applica gli effetti dei tratti

        foreach (Tratto tratto in gameVariable.Tratti.Active)
        {

            if(tratto.durata >= 0){ 

                switch (tratto.tipo) 
                {
                    case TrattoType.REROLL:
                        gameVariable.doni = 4;
                        gameVariable.coroneOro += 1;
                    break;

                    case TrattoType.SADICO:

                        gameVariable.moltiplicatoreMonete /= mulMoneteSadico;
                    
                        if(gameVariable.vite == 1){ 
                            mulMoneteSadico = 3;
                        }
                        if(gameVariable.vite == 2){
                            mulMoneteSadico = 2;
                        }
                        if(gameVariable.vite >= 3){
                            mulMoneteSadico = 1;
                        }

                        gameVariable.moltiplicatoreMonete *= mulMoneteSadico;

                    break;

                    case TrattoType.CONVERSIONE:
                        int viteAggiunte = gameVariable.monete / 400;
                        gameVariable.monete -= 400 * viteAggiunte;
                        gameVariable.vite += viteAggiunte;
                    break;

                    case TrattoType.RENDITA:

                        gameVariable.monete += 4;

                        if(tratto.durata == 0){

                            if(renditaFlag == false){

                                tratto.durata = 5;
                                renditaFlag = true;
                                gameVariable.obstacleWaitTime /= 2;

                            } else {

                                tratto.durata = 25;
                                renditaFlag = false;
                                gameVariable.obstacleWaitTime *= 2;
                            }
                            
                        }
                        
                    break;

                    case TrattoType.SHOPHATER:

                        if(tratto.durata > 999){
                            gameVariable.vite -= 1;
                            tratto.durata = 60;
                        }
                        
                        if(gameVariable.Shop.Active.Count == 0){ //se non ci sono oggetti nello shop
                            
                            if(tratto.durata == 0){

                                tratto.durata = 60;
                                gameVariable.vite += 1;
                            }

                        } else {

                            tratto.durata = 0;
                        }
                        
                    break;

                    case TrattoType.ASCESA:
                        if(tratto.durata == 30){
                            gameVariable.jumpForce *= 1.2f;
                        }
                        if(tratto.durata == 0){
                            gameVariable.ySpeed *= 0.85f;
                        }
                    break;

                    case TrattoType.SHOPVOLANTE:
                        gameVariable.monete += 100;
                        gameVariable.openShop = true;
                        tratto.durata = 0;
                    break;

                    case TrattoType.INVESTIMENTO:

                        if(tratto.durata == 60){
                            holderMoneteInvestimento = gameVariable.monete;
                            gameVariable.monete = 0;
                        }
                        
                        if(tratto.durata == 0){
                            gameVariable.monete += holderMoneteInvestimento * 2;
                        }

                    break;

                    case TrattoType.RICCHIRICCHISSIMI:
                        int moltiplicatore = gameVariable.monete / 100;
                        gameVariable.monete += moltiplicatore;
                    break;

                    case TrattoType.LOWG:

                        if(tratto.durata == 0){

                            if(altissimoFlag == false){

                                tratto.durata = 5;
                                altissimoFlag = true;
                                gameVariable.gravity /= 3;

                            } else {

                                tratto.durata = 30;
                                altissimoFlag = false;
                                gameVariable.gravity *= 3;
                            }
                            
                        }

                    break;

                    case TrattoType.ALTISSIMO:
                        gameVariable.monete += (int) (gameVariable.player.position.y * 1.5f);
                    break;

                    case TrattoType.LUDOPATIA: //TODO KIND OF BUGGED
                        System.Random rnd = new System.Random();
                        gameVariable.monete += rnd.Next(10, 600);
                        Tratto gained = gameVariable.Tratti.Draw();
                        gameVariable.Tratti.Active.Add(gained);
                        gameVariable.Tratti.Pool.Remove(gained);
                    break;
                    
                }
                tratto.durata -= 1;
                
            } 

        }
    }
}
