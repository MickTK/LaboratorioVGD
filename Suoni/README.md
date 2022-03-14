# Suoni
## Premessa
A lezione abbiamo visto troppo poco per poter implementare un sistema audio decente quindi ho seguito questo [tutorial](https://www.youtube.com/watch?v=6OT43pvUyfY). Cito le parole del prof: "Ci aspettiamo che facciate voi quello che abbiamo visto a lezione".

## Lista suoni
### Menu
- "In" -> Bottoni (es.: Nuovo gioco, Impostazioni, etc.)
- "Out" -> Bottoni per tornare al menu precedente
### Gioco
- "Moneta" -> Quando viene raccolta una moneta
- "Oggetto" -> Quando viene raccolto un oggetto
- "Salto" -> Quando il giocatore salta
- "Fine effetto" -> Quando finisce l'effetto acquisito dal giocatore
### Altro
- "Sottofondo in game" -> Tema principale

## Riprodurre un suono
- Collocare il prefab "AudioManager" nella scena (solo uno per scena)

- Richiamare il seguente metodo dallo script del giocatore o menu
````
// Sostituire la X con il nome del file audio, ad esempio "Sottofondo in game"
FindObjectOfType<AudioManager>().Play("X");
````
