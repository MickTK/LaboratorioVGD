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
        
        //TODO: carica i punteggi in currentdata se il file savePath esiste, altrimenti salva i punteggi di default su file
        //inizializzo i punteggi di default
        SerializableHS defaultGame= new SerializableHS();
        defaultGame.name="no name";
        defaultGame.score=0;

        currentData.highScores[0]=defaultGame;
        currentData.highScores[1]=defaultGame;
        currentData.highScores[2]=defaultGame;
        
        //carico il vecchio file se esiste
        if(File.Exists(savePath)){
            
                FileStream fs = File.Open(savePath,FileMode.Open);

                currentData= (GameData) formatter.Deserialize(fs);
                fs.Close();

        }

        

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
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("PlayerName", playerName.text);

        //TODO: carica la scena Level1
        PlayerPrefs.SetInt("currentLevel",1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
    
    
}
