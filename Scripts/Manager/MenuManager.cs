using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    int highscore;
    int difficolta = 2;
    Button buttonEasy;
    Button buttonMedium;
    Button buttonHard;
    Button buttonMusic;
    Button buttonEffects;
    public GameObject menuSettings;
    public GameObject menuButton;
    static Color WHITE = Color.white;
    static Color GREEN = Color.green;

    private void Start() {
        highscore = Save.loadScore();

        buttonEasy = GameObject.Find("EasyButton").GetComponent<Button>();
        buttonMedium = GameObject.Find("MediumButton").GetComponent<Button>();
        buttonHard = GameObject.Find("HardButton").GetComponent<Button>();
        buttonMusic = GameObject.Find("MusicButton").GetComponent<Button>();
        buttonEffects = GameObject.Find("EffectsButton").GetComponent<Button>();
    }

    public void SetButtonColor(Button button, Color color){
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        colors.selectedColor = color;
        button.colors = colors;
    }

    public void OpenGame(){
        SceneManager.LoadScene("Main");
    }
    
    public void OpenSettings(){

        menuButton.SetActive(false);
        menuSettings.SetActive(true);
    }

    public void CallButtonClick(string buttonType){

        switch (buttonType)
        {
            case "Easy":
            difficolta = 1;
            SetButtonColor(buttonEasy, GREEN);
            SetButtonColor(buttonMedium, WHITE);
            SetButtonColor(buttonHard, WHITE);
            break;

            case "Medium":
            difficolta = 2;
            SetButtonColor(buttonEasy, WHITE);
            SetButtonColor(buttonMedium, GREEN);
            SetButtonColor(buttonHard, WHITE);
            break;

            case "Hard":
            difficolta = 3;
            SetButtonColor(buttonEasy, WHITE);
            SetButtonColor(buttonMedium, WHITE);
            SetButtonColor(buttonHard, GREEN);
            break;

            case "Music":
            SetMusicVolume();
            break;

            case "Effects":
            SetEffectsVolume();
            break;
            
            default:
            break;
        }
    }

    public void CloseSettings(){

        menuButton.SetActive(true);
        menuSettings.SetActive(false);
    }

    public void OpenMainMenu(){
        SceneManager.LoadScene("StartingMenu");
    }

    public void QuitGame(){
        // save any game data here
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

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
        {

            FindObjectOfType<AudioManager>().SetVolume(0f, "Music");
            SetButtonColor(buttonMusic, WHITE);

        } else {

            FindObjectOfType<AudioManager>().SetVolume(1f, "Music");
            SetButtonColor(buttonMusic, GREEN);
        }
    }
    // Cambia volume degli effetti
    public void SetEffectsVolume()
    {
        if (FindObjectOfType<AudioManager>().effectOn)
        {

            FindObjectOfType<AudioManager>().SetVolume(0f, "Sound");
            SetButtonColor(buttonEffects, WHITE);

        } else {

            FindObjectOfType<AudioManager>().SetVolume(1f, "Sound");
            SetButtonColor(buttonEffects, GREEN);
        }
            
    }
}
