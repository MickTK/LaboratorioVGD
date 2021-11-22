using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    //TODO: Creare un array di oggetti di tipo SerializableHS di lunghezza 3 chiamato highScores.
}

[System.Serializable]
public struct SerializableHS : IComparable<SerializableHS>{
    //Versione di una struttura serializabile leggermente più complessa rispetto a quella vista a lezione.
    //Estende IComparable e implementa CompareTo in modo da poter essere ordinata quando si trova in una lista o in un array. 
    //I tipi con il punto interrogativo si chiamano nullable types. Se siete curiosi di sapere come funzionanano e come si usano fate una veloce ricerca su google.  

    #nullable enable
    private int? _score;
    public int score {get {return _score ?? 0;} set {_score = value;}}
    private string? _name;
    public string name {get {return _name ?? "no name";} set {_name = value;}}
    #nullable disable

    public int CompareTo(SerializableHS other)
    {
        return score.CompareTo(other.score);
    }
}

public class Manager : MonoBehaviour
{
    public Text countText;
    private int score;
    private string savePath;

    void Start()
    {
        score = 0;
    }
    public void UpdateScore()
    {
        //TODO: Aumenta lo score di 1.
        //TODO: Aggiorna il testo del punteggio.
    }

    public void saveData()
    {
        
        savePath = Application.persistentDataPath + "/scores.sav";
    
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Open(savePath, FileMode.Open);
        GameData currentData;
        currentData = (GameData)formatter.Deserialize(fileStream);
        
        fileStream.Close();
        fileStream = File.Open(savePath, FileMode.Create); 
        UpdateScores(ref currentData, PlayerPrefs.GetString("PlayerName"), score);
        
        formatter.Serialize(fileStream, currentData);
        fileStream.Close();
    }

    private void UpdateScores(ref GameData g, string playerName, int score)
    {
        //TODO: Aggiornare i dati contenuti in g con i dati della partita corrente. La classifica deve essere ordinata in ordine decrescente.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
