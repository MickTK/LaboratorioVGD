using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public GameObject itemUI;
    ItemDisplayer itemDisplayer1;
    ItemDisplayer itemDisplayer2;
    ItemDisplayer itemDisplayer3;
    ItemDisplayer itemDisplayer4;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public ItemEffects itemEffects;
    Deck<Item> deckItem = new Deck<Item>("Shop/Object");

    void Start(){

        itemDisplayer1 = item1.GetComponent<ItemDisplayer>();
        itemDisplayer2 = item2.GetComponent<ItemDisplayer>();
        itemDisplayer3 = item3.GetComponent<ItemDisplayer>();
        itemDisplayer4 = item4.GetComponent<ItemDisplayer>();

        Button btn1 = itemDisplayer1.GetComponent<Button>();
        btn1.onClick.AddListener(ClickOne);

        Button btn2 = itemDisplayer2.GetComponent<Button>();
        btn2.onClick.AddListener(ClickTwo);
                
        Button btn3 = itemDisplayer3.GetComponent<Button>();
        btn3.onClick.AddListener(ClickThree);

        Button btn4 = itemDisplayer4.GetComponent<Button>();
        btn4.onClick.AddListener(ClickFour);

        itemUI.SetActive(false);
    }

    void ClickOne(){
        item1.SetActive(false);
        itemEffects.DeckItem.DeckAccess.Add(itemDisplayer1.Item);
	}

    void ClickTwo(){
        item2.SetActive(false);
        itemEffects.DeckItem.DeckAccess.Add(itemDisplayer2.Item);
	}

    void ClickThree(){
        item3.SetActive(false);
        itemEffects.DeckItem.DeckAccess.Add(itemDisplayer3.Item);
	}

    void ClickFour(){
        item4.SetActive(false);
        itemEffects.DeckItem.DeckAccess.Add(itemDisplayer4.Item);
	}
    
    void Update(){

        if (Input.GetKeyDown("z"))
        {
            itemUI.SetActive(true);
            itemDisplayer1.Item = deckItem.Pick();
            itemDisplayer2.Item = deckItem.Pick();
            itemDisplayer3.Item = deckItem.Pick();
            itemDisplayer4.Item = deckItem.Pick();
        }
    }

}
