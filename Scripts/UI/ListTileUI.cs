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
        this.text.text = item.durata.ToString();
    }

    public void SetValues(Tratto item){

        this.image.sprite = item.artwork;
        this.text.text = item.durata.ToString();
    }
}
