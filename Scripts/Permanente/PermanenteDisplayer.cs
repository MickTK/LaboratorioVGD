using UnityEngine;
using UnityEngine.UI;

public class PermanenteDisplayer : MonoBehaviour
{
    Permanente permanente;
    public Text titleText;
    public Image artworkImage;
    public Text descrText;
    public Permanente Permanente 
    { 
        get { return permanente; } 
        set 
        { 
            permanente = value; 
            titleText.text = permanente.titolo;
            artworkImage.sprite = permanente.artwork;
            descrText.text = permanente.descrizione;
        } 
    }
}
