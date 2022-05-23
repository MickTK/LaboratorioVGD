using UnityEngine;

public enum ItemType
{
    MEDICINE,
    KITSOCCORSO,
    CUOREDORO,
    ZUPPANONNA,
    MOLTIPLICATORE,
    CAFFE,
    SCAFFALEVUOTO,
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
