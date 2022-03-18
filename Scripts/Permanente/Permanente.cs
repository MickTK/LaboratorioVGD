using UnityEngine;

public enum PermType 
{
    REROLL,
    NUOVERECLUTE,
    RAMPA
}

[CreateAssetMenu(fileName = "Nuovo Permanente", menuName = "Permanente")]
public class Permanente : ScriptableObject // potenziamento persistente e permanente 
{
    public PermType tipo;
    public string titolo;
    public string descrizione;
    public Sprite artwork;
    public bool activable = true; // se il potenziamento è attivabile
}
