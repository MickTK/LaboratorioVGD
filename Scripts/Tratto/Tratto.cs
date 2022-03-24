using UnityEngine;

public enum TrattoType 
{
    REROLL,
    NUOVERECLUTE,
    RAMPA
}

[CreateAssetMenu(fileName = "Nuovo Tratto", menuName = "Tratto")]
public class Tratto : ScriptableObject // potenziamento persistente e permanente 
{
    public TrattoType tipo;
    public string titolo;
    public string descrizione;
    public Sprite artwork;
    public bool activable = true; // se il potenziamento è attivabile
}
