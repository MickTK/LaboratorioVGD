using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{
    GameVariable gameVariable;
    Deck<Item> deckItem = new Deck<Item>("Shop/Object");
    public Deck<Item> DeckItem { get => deckItem; set => deckItem = value; }

    void Start(){
        gameVariable = GetComponent<GameVariable>();
    }

    void Update(){

        foreach (var item in DeckItem.DeckAccess)
        {
            //Debug.Log(item.titolo);
        }
    }
}
