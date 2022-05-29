using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuContoller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Suono click per andare avanti in un menu
    public void ClickSuonoIn()
    {
        FindObjectOfType<AudioManager>().Play("In");
    }
    // Suono click per tornare indietro in un menu
    public void ClickSuonoOut()
    {
        FindObjectOfType<AudioManager>().Play("Out");
    }
    // Cambia volume della musica
    public void SetMusicVolume()
    {
        if (FindObjectOfType<AudioManager>().musicOn)
            FindObjectOfType<AudioManager>().SetVolume(0f, "Music");
        else
            FindObjectOfType<AudioManager>().SetVolume(1f, "Music");
    }
    // Cambia volume degli effetti
    public void SetEffectsVolume()
    {
        if (FindObjectOfType<AudioManager>().effectOn)
            FindObjectOfType<AudioManager>().SetVolume(0f, "Sound");
        else
            FindObjectOfType<AudioManager>().SetVolume(1f, "Sound");
    }
}
