# Suoni
## Premessa
A lezione abbiamo visto troppo poco per poter implementare un sistema audio decente quindi ho seguito questo [tutorial](https://www.youtube.com/watch?v=6OT43pvUyfY). Cito le parole del prof: "Ci aspettiamo che facciate voi quello che abbiamo visto a lezione".

## Lista suoni
### Menu
- "MouseIn" -> Il cursore viene posizionato sopra un bottone
- "In" -> Viene premuto un bottone
- "Out" -> Viene premuto un bottone per tornare al menu precedente
### Gioco
- "Moneta" -> Viene raccolta una moneta
- "Oggetto" -> Viene raccolto un oggetto
- "Salto" -> Il giocatore salta
- "Fine effetto" -> Finisce l'effetto acquisito dal giocatore
- "Bonk" -> Il giocatore riceve danno
### Altro
- "Potato" -> Tema principale

## Riprodurre un suono
- Collocare il prefab "AudioManager" nella scena (solo uno per scena)

- Richiamare il seguente metodo dallo script del giocatore o menu
````
// Sostituire la X con il nome del file audio, ad esempio "Sottofondo in game"
FindObjectOfType<AudioManager>().Play("X");
````
