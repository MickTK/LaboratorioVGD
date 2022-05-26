using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save : MonoBehaviour
{
    // C:\Users\<user>\AppData\LocalLow\DefaultCompany\VGD - Progetto finale
    private static string savePath = Application.persistentDataPath + "/" + "score.save";

    // Metodo per il salvataggio del miglior punteggio su file
    public static void saveScore(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open(savePath, FileMode.Create))
        {
            formatter.Serialize(fileStream, score);
        }
    }

    // Metodo per caricare il miglior punteggio presente su file
    public static int loadScore()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = File.Open(savePath, FileMode.Open))
            {
                int score = (int)formatter.Deserialize(fileStream);
                return score;
            }
        }
        return 0;
    }
}
