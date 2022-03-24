using UnityEngine;

/*

- - - SHOP 
4 item per shop, randomico

1 MEDICINALI, 200 monete
1 cuore in più 

2 KIT SOCCORSO 400 monete
2 cuori in più

3 ANTIPROIETTILE, 300 monete
2 cuori grigi

4 CORAZZA PESANTE 500 monete
4 cuori grigi

5 ZUPPA DELLA NONNA, 500 monete
1 cuore permanente extra 

6 MOLTIPLICATORE, 300 monete
Per 30 secondi le monete valgono doppio

7 CAFFE' 100 monete
ostacoli 10% più lento per 60 secondi

8 AMICO CERCHIO 200 monete
vengono raccolte le monete anche dove passa il cerchio, per 1 minuto

9 CRYPTOVALUTA 1000 monete
tra 30 secondi guadagni 1300 monete

10 MEDITAZIONE 500 monete
per 3 minuti, ogni minuto rigeneri un cuore

11 A BUON RENDERE 0 monete
ottieni 1 vita e 1 cuore grigio. tra 1 minuto ti toglie 300 monete, se non hai le monete perdi le vite e i cuori

12 AZZARDO 0 monete
ottieni 2 vite e 2 cuori grigi. tra 1 minuto ti toglie 700 monete, se non hai le monete perdi le vite e i cuori

13 MORFINA 100 monete
puoi muoverti lateralmente più veloce del 20% per 1 minuto

*/
public enum ItemType
{
    MEDICINE,
    KITSOCCORSO,
    ANTIPROIETTILE,
    CORAZZAPESANTE,
    ZUPPANONNA,
    MOLTIPLICATORE,
    CAFFE,
    AMICOCERCHIO,
    CRYPTOVALUTA, 
    MEDITAZIONE,
    ABUONRENDERE,
    AZZARDO,
    MORFINA
}

[CreateAssetMenu(fileName = "Nuovo Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public ItemType tipo;
    public string titolo;
    public string descrizione;
    public Sprite artwork;
    public int prezzo;
    public int durata;
}
