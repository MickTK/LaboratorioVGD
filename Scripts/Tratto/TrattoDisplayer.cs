using UnityEngine;
using UnityEngine.UI;

public class TrattoDisplayer : MonoBehaviour
{
    Tratto tratto;
    public Text titleText;
    public Image artworkImage;
    public Text descrText;
    public Tratto Tratto 
    { 
        get { return tratto; } 
        set 
        { 
            tratto = value; 
            titleText.text = tratto.titolo;
            artworkImage.sprite = tratto.artwork;
            descrText.text = tratto.descrizione;
        } 
    }
}
