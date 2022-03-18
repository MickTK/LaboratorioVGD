using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayer : MonoBehaviour
{
    Item item;
    public Text titleText;
    public Image artworkImage;
    public Text descrText;
    public Text prezzo;
    public Item Item 
    { 
        get { return item; } 
        set 
        { 
            item = value; 
            titleText.text = item.titolo;
            artworkImage.sprite = item.artwork;
            descrText.text = item.descrizione;
            prezzo.text = item.prezzo.ToString();
        } 
    }}
