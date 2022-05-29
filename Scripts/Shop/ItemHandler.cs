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
    GameVariable gameVariable;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject exitButton;

    void Start(){

        gameVariable = GetComponent<GameVariable>();

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
                
        Button exit = exitButton.GetComponent<Button>();
        exit.onClick.AddListener(Exit);

        itemUI.SetActive(false);
    }

    void ClickOne(){

        if(itemDisplayer1.Item.prezzo <= gameVariable.monete){

            item1.SetActive(false);
            gameVariable.buyedItems++;
            Item newItem = Instantiate(itemDisplayer1.Item);
            newItem.titolo = Random.Range(1.0f, 999999.0f).ToString();
            gameVariable.Shop.Active.Add(newItem);
            gameVariable.monete -= itemDisplayer1.Item.prezzo;
        }
	}

    void ClickTwo(){

        if(itemDisplayer2.Item.prezzo <= gameVariable.monete){

            item2.SetActive(false);
            gameVariable.buyedItems++;
            Item newItem = Instantiate(itemDisplayer2.Item);
            newItem.titolo = Random.Range(1.0f, 999999.0f).ToString();
            gameVariable.Shop.Active.Add(newItem);
            gameVariable.monete -= itemDisplayer2.Item.prezzo;
        }
	}

    void ClickThree(){

        if(itemDisplayer3.Item.prezzo <= gameVariable.monete){

            item3.SetActive(false);
            gameVariable.buyedItems++;
            Item newItem = Instantiate(itemDisplayer3.Item);
            newItem.titolo = Random.Range(1.0f, 999999.0f).ToString();
            gameVariable.Shop.Active.Add(newItem);
            gameVariable.monete -= itemDisplayer3.Item.prezzo;
        }
	}

    void ClickFour(){

        if(itemDisplayer4.Item.prezzo <= gameVariable.monete){

            item4.SetActive(false);
            gameVariable.buyedItems++;
            Item newItem = Instantiate(itemDisplayer4.Item);
            newItem.titolo = Random.Range(1.0f, 999999.0f).ToString();
            gameVariable.Shop.Active.Add(newItem);
            gameVariable.monete -= itemDisplayer4.Item.prezzo;
        }
	}
    
    void Exit(){

        gameVariable.isGameRunning = true;
        itemUI.SetActive(false);
        item4.SetActive(true);
        item3.SetActive(true);
        item2.SetActive(true);
        item1.SetActive(true);
    }

    void Update(){

        if (gameVariable.openShop == true || Input.GetKeyDown("c"))
        {
            StartCoroutine(OpenShop());
            gameVariable.openShop = false;
        }
    }

    IEnumerator OpenShop(){
        
        yield return new WaitForSeconds(1f);

        gameVariable.isGameRunning = false;
        itemUI.SetActive(true);
        itemDisplayer1.Item = gameVariable.Shop.Draw();
        itemDisplayer2.Item = gameVariable.Shop.Draw();
        itemDisplayer3.Item = gameVariable.Shop.Draw();
        itemDisplayer4.Item = gameVariable.Shop.Draw();
    }

}
