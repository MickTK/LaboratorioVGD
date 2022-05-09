# AudioManager
Classe che gestisce la riproduzione dei suoni nel gioco

## Attributi
- `sounds`: vettore di suoni
- `startSoundIndex`: indice della canzone da riprodurre una volta caricata la scena
- `instance`: istanza corrente dell'audio manager

## Metodi
````
public void Play(string name)
````
Riproduce un suono.
- Parametri
    - `name`: nome del suono da riprodurre (presente nel vettore `sounds`)
````
public void Stop(string name)
````
Interrompe un suono.
- Parametri
    - `name`: nome del suono da interrompere
````
public void SetVolume(float volume, string type)
````
Modifica il volume di un dato tipo di suono.
- Parametri
    - `volume`: il nuovo volume (daf 0f a 1f)
    - `type`: si riferisce al tipo di suono
        - "Music" per la musica
        - "Sound" per i suoni
