using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    int highscore;
    int difficolta = 2;
    public GameObject menuSettings;
    public GameObject menuButton;
    static Color WHITE = Color.white;
    static Color GREEN = Color.green;
    static string EASY = "EasyButton";
    static string MEDIUM = "MediumButton";
    static string HARD = "HardButton";
    static string MUSIC = "MusicButton";
    static string EFFECTS = "EffectsButton";

    private void Start() {

        highscore = Save.loadScore();
    }

    public void SetButtonColor(string buttonName, Color color){
        
        Button button = GameObject.Find(buttonName).GetComponent<Button>();
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

        switch(difficolta){

            case 1:
            SetButtonColor(EASY, GREEN);
            SetButtonColor(MEDIUM, WHITE);
            SetButtonColor(HARD, WHITE);
            break;          
              
            case 2:
            SetButtonColor(EASY, WHITE);
            SetButtonColor(MEDIUM, GREEN);
            SetButtonColor(HARD, WHITE);
            break;   

            case 3:
            SetButtonColor(EASY, WHITE);
            SetButtonColor(MEDIUM, WHITE);
            SetButtonColor(HARD, GREEN);
            break;

        }

        if (FindObjectOfType<AudioManager>().GetMusicVolume())
        {
            SetButtonColor(MUSIC, GREEN);
        } else {
            SetButtonColor(MUSIC, WHITE);
        }

        if (FindObjectOfType<AudioManager>().GetEffectVolume())
        {
            SetButtonColor(EFFECTS, GREEN);
        } else {
            SetButtonColor(EFFECTS, WHITE);
        }
    }

    public void CallButtonClick(string buttonType){

        switch (buttonType)
        {
            case "Easy":
            difficolta = 1;
            SetButtonColor(EASY, GREEN);
            SetButtonColor(MEDIUM, WHITE);
            SetButtonColor(HARD, WHITE);
            break;

            case "Medium":
            difficolta = 2;
            SetButtonColor(EASY, WHITE);
            SetButtonColor(MEDIUM, GREEN);
            SetButtonColor(HARD, WHITE);
            break;

            case "Hard":
            difficolta = 3;
            SetButtonColor(EASY, WHITE);
            SetButtonColor(MEDIUM, WHITE);
            SetButtonColor(HARD, GREEN);
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
        if (FindObjectOfType<AudioManager>().GetMusicVolume())
        {

            FindObjectOfType<AudioManager>().SetVolume(0f, "Music");
            SetButtonColor(MUSIC, WHITE);


        } else {

            FindObjectOfType<AudioManager>().SetVolume(1f, "Music");
            SetButtonColor(MUSIC, GREEN);
        }
    }
    // Cambia volume degli effetti
    public void SetEffectsVolume()
    {
        if (FindObjectOfType<AudioManager>().GetEffectVolume())
        {

            FindObjectOfType<AudioManager>().SetVolume(0f, "Sound");
            SetButtonColor(EFFECTS, WHITE);

        } else {

            FindObjectOfType<AudioManager>().SetVolume(1f, "Sound");
            SetButtonColor(EFFECTS, GREEN);
        }
    }
}
