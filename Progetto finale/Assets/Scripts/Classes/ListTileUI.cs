using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTileUI : MonoBehaviour
{
    [SerializeField]
    public Image image;
    public Text text;

    public void SetValues(Item item){

        this.image.sprite = item.artwork;
        this.text.text = CheckText(item.durata.ToString());
    }

    public void SetValues(Tratto item){

        this.image.sprite = item.artwork;
        this.text.text = CheckText(item.durata.ToString());
    }

    private string CheckText(string text){
        
        if(Int32.Parse(text) > 999){
            return "∞";
        }

        if(Int32.Parse(text) < 0){
            return "";
        }

        return text;
    }
}
