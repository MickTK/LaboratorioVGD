using UnityEngine;

public enum TrattoType 
{
    REROLL,
    NUOVERECLUTE,
    RAMPA
}

/*

1 REROLL
ottieni altri 3 possibilità di permanenti

2 SADICO
il valore delle monete viene moltiplicato se hai poche vite. 
1 vita = 2x; 2 vite = 1.5x; 3 vite o più = 1x 

3 DANNO CALCOLATO
ogni volta che perdi un cuore, ottieni 200 monete e diventi immortale per 5 secondi

4 CONVERSIONE
converti tutte le monete che hai adesso in vite permanenti, 1 vita = 400 gold

5 STRADA SICURA
nei prossimi 15 secondi al posto degli ostacoli ci sono monete 

6 RENDITA
ottieni 5 monete al secondo per 100 secondi

7 SHOP HATER
se non acquisti nessun oggetto da nessuno shop ottieni 2 vite extra e la rigenerazione di una vita al minuto.

8 QUADRIFOGLIO
Hai il doppio della possibilità di trovare monete di alto valore

9 CORSA ALL'ORO
lo shop costa il triplo ma non puoi trovare monete non rare (di valore 1)

10 SHOP VOLANTE
ottieni 100 monete, apri lo shop

11 VOLO SOSPESO
ogni 20 secondi, saltando in volo, puoi fluttuare nell'aria per 3 secondi.

12 GHOST TOWN
ogni 50 secondi, abbassandoti due volte di fila, puoi diventare un fantasma per 5 secondi.

13 INVESTIMENTO
vengono prese tutte le tue monete. Se sopravvivi per 1 minuto vengono restituite e raddoppiate

14 FRENO A MANO
Ogni 5 secondi tutti i nemici in movimento vengono rallentati per 2 secondi del 60% 

15 RICCHI RICCHISSIMI
Ogni 100 monete che hai ottieni 1 moneta al secondo

16 SOTTOBANCO
in ogni shop c'è un oggetto gratuito casuale

17 ALTISSIMO
ogni 30 secondi puoi saltare il doppio 

18 DISCOUNT
tutti i prezzi degli shop sono dimezzati

19 VOLARE ALTO
più sei in alto rispetto al terreno, più denaro guadagni.

20 LUDOPATIA
ottieni un permanente casuale e una quantità casuale di monete

*/

[CreateAssetMenu(fileName = "Nuovo Tratto", menuName = "Tratto")]
public class Tratto : ScriptableObject // potenziamento persistente e permanente 
{
    public TrattoType tipo;
    public string titolo;
    public string descrizione;
    public Sprite artwork;
    public bool activable = true; // se il potenziamento è attivabile
    public int durata;
}
