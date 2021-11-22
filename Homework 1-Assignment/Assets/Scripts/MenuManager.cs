using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField playerName;
    private string savePath;
    public Text score1;
    public Text score2;
    public Text score3;
    

    // Start is called before the first frame update
    void Start()
    {
        savePath = Application.persistentDataPath + "/scores.sav";
        BinaryFormatter formatter = new BinaryFormatter();
        GameData currentData = new GameData(); //creo i punteggi di default
        
        //TODO: carica i punteggi in currentdata se il file savePath esite, altrimenti salva i punteggi di default su file

        score1.text = currentData.highScores[0].name + ": " + currentData.highScores[0].score;
        score2.text = currentData.highScores[1].name + ": " + currentData.highScores[1].score;
        score3.text = currentData.highScores[2].name + ": " + currentData.highScores[2].score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        //TODO: salva il nome del giocatore nelle playerprefs con chiave "PlayerName"
        //TODO: carica la scena Level1
    }
    
    
}
