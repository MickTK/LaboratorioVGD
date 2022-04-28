# Savefile
Classe utilizzata per salvare e carica i dati di gioco su/da file.

## Metodi
````
public static void save<T>(T data, string filename)
````
Serializza e salva un oggetto su file.
Path relativo: 'Application.persistentDataPath'.
Nota importante: T deve essere pubblico.
- Parametri
    - ```` data ````: dati da salvare
    - ```` filename ````: nome del file

````
public static T load<T>(string filename)
````
Deserializza un oggetto da file.
Path relativo: 'Application.persistentDataPath'.
- Parametri
    - ```` filename ````: nome del file

## Esempio
````
// Serializza 'data' e scrive nel file chiamato "CiaoMondo.txt"
DataObj data = new DataObj(10, "Ciao");
Savefile.save<DataObj>(data, "CiaoMondo.txt");

// Legge e deserializza in 'data' dal file chiamato "CiaoMondo.txt"
data = Savefile.load<DataObj>("CiaoMondo.txt");
````
