using UnityEngine;
public enum ItemType
{
    MEDICINE,
    ANTIPROIETTILE,
    ZUPPANONNA,
    MOLTIPLICATORE,
    FORTUNA
}

[CreateAssetMenu(fileName = "Nuovo Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public ItemType tipo;
    public string titolo;
    public string descrizione;
    public Sprite artwork;
    public int prezzo;
}
