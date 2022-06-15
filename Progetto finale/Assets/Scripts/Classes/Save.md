# Save
Classe per salvare e carica il miglior punteggio su/da file.

Path relativo: `Application.persistentDataPath`

Nome file: `score.save`

## Metodi
### saveScore
````
public static void saveScore(int score)
````
Serializza e salva il punteggio su file.
- Parametri:
    - ` score `: punteggio da salvare

### loadScore
````
public static int loadScore()
````
Legge, deserializza e restituisce il punteggio.

## Esempio
````
// Salvataggio
Save.saveScore(10255);

// Caricamento
int score = Save.loadScore();
````
