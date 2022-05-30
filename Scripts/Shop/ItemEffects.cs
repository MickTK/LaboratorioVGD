using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{
    GameVariable gameVariable;

    void Start(){

        gameVariable = GetComponent<GameVariable>();
        StartCoroutine(ShopEffects());    
    }

    IEnumerator ShopEffects()
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

        foreach (Item item in gameVariable.Shop.Active)
        {
            switch (item.tipo)
            {
                case ItemType.MEDICINE:
                    gameVariable.vite += 1;
                break;
                
                case ItemType.KITSOCCORSO:
                    gameVariable.vite += 2;
                break;
                
                case ItemType.CORONEDORO:
                    gameVariable.coroneOro += 2;
                break;
                
                case ItemType.ZUPPANONNA:
                    gameVariable.doni += 1;
                    gameVariable.vite += 1;
                break;
                
                case ItemType.MOLTIPLICATORE:
                    if(item.durata == 30){
                        gameVariable.moltiplicatoreMonete *= 2;
                    }
                    if(item.durata == 0){
                        gameVariable.moltiplicatoreMonete /= 2;
                    }
                break;

                case ItemType.CAFFESTRANO:
                    if(item.durata == 60){
                        gameVariable.xSpeed *= 0.85f;
                    }
                    if(item.durata == 0){
                        gameVariable.xSpeed /= 0.85f;
                    }
                break;
                
                case ItemType.SCAFFALEVUOTO:
                break;
                
                case ItemType.CRYPTOVALUTA:
                    if(item.durata == 0){
                        gameVariable.monete += 1300;
                    }
                break;
                
                case ItemType.MEDITAZIONE:
                    if(item.durata == 120 || item.durata == 60 || item.durata == 0){
                        
                        gameVariable.vite += 1;
                    }
                break;
                
                case ItemType.ABUONRENDERE:

                    if(item.durata == 60){

                        gameVariable.vite += 1;

                        gameVariable.coroneOro += 1;
                    }

                    if(item.durata == 0){

                        if(gameVariable.monete >= 300){

                            gameVariable.monete -= 300; 

                        } else {

                            gameVariable.vite -= 1;
                            gameVariable.coroneOro -= 1;
                        }
                    }

                break;
                
                case ItemType.AZZARDO:

                    if(item.durata == 60){

                        gameVariable.vite += 2;

                        gameVariable.coroneOro += 2;
                    }

                    if(item.durata == 0){

                        if(gameVariable.monete >= 700){

                            gameVariable.monete -= 700; 

                        } else {

                            gameVariable.vite -= 2;
                            gameVariable.coroneOro -= 2;
                        }
                    }

                break;
                
                case ItemType.MORFINA:
                    if(item.durata == 60){
                        gameVariable.xSpeed *= 1.2f;
                    }
                    if(item.durata == 0){
                        gameVariable.xSpeed /= 1.2f;
                    }
                break;
            }
            item.durata -= 1;
        }
    }

    void Exprire(){

        for (int i = gameVariable.Shop.Active.Count - 1; i >= 0; i--)
        {
            if(gameVariable.Shop.Active[i].durata < 0){

                gameVariable.Shop.Active.Remove(gameVariable.Shop.Active[i]);
            }
        }
    }
}
