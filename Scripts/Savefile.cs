using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;

public class Savefile : MonoBehaviour
{
    // Serializza in xml e salva in binario gli attributi di un oggetto su file
    public static void save<T>(T data, string filename)
    {
        // Percorso in cui verrà salvato il file binario
        string savePath = Application.persistentDataPath + "/" + @filename;
        /* Per test: string savePath = Directory.GetCurrentDirectory() + "/" + @filename;*/
        // Crea e rilascia l'oggetto che conterrà lo stream del file xml
        using (StringWriter textWriter = new StringWriter())
        {
            // Nuovo oggetto per la serializzazione
            XmlSerializer xs = new XmlSerializer(typeof(T));
            // Serializza i dati passati come input al metodo e li salva in 'textWriter'
            xs.Serialize(textWriter, data);
            // Oggetto per la formattazione in binario
            BinaryFormatter formatter = new BinaryFormatter();
            // Apre e chiude lo stream per la scrittura su file
            using (FileStream fileStream = File.Open(@savePath, FileMode.Create))
            {
                // Scrive in binario su file il contenuto di 'textWriter' (ossia l'XML)
                formatter.Serialize(fileStream, textWriter.ToString());
            }
        }
    }

    // Deserializza da binario a UTF e da XML a oggetto generico il contenuto di un file
    public static T load<T>(string filename)
    {
        // Percorso del file binario
        string savePath = Application.persistentDataPath + "/" + @filename;
        try
        {
            if (File.Exists(@savePath))
            {
                // Stringa che conterrà l'XML
                String data;
                // Oggetto che convertirà i dati letti dal file, da binario a UTF
                BinaryFormatter formatter = new BinaryFormatter();
                // Apre e chiude il file da cui leggere i dati
                using (FileStream fileStream = File.Open(savePath, FileMode.Open))
                {
                    // Converte i dati binari del file e li salva in 'data'
                    data = (string)formatter.Deserialize(fileStream);
                }
                // Oggetto per deserializzare l'XML
                XmlSerializer ser = new XmlSerializer(typeof(T));
                // Apre lo stream per la deserializzazione
                using (TextReader reader = new StringReader(data))
                {
                    // Deserializza e restituisce l'oggetto deserializzato
                    return (T)ser.Deserialize(reader);
                }
            }
        }
        catch (Exception e)
        {
            // Stampa su console il messaggio d'errore
            Console.WriteLine(e.Message);
        }
        return default;
    }
}
