using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariable : MonoBehaviour
{
    public Transform player;
    public int monete;
    public int dadi;
    public int punteggio;
    public byte vite;
    public byte vitemassime;
    Deck<Permanente> permanenteActive = new Deck<Permanente>("Permanente/Object");
    public Deck<Permanente> PermanenteActive { get => permanenteActive; set => permanenteActive = value; }
}
