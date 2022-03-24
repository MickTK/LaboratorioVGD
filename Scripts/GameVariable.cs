using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariable : MonoBehaviour
{
    public bool isGameRunning;
    public Transform player;
    public int monete;
    public int dadi;
    public int punteggio;
    public byte vite;
    public byte viteMassime;
    public byte viteNonRecuperabili;
    Deck<Tratto> tratti = new Deck<Tratto>("Interface/Tratto/Object");
    public Deck<Tratto> Tratti { get => tratti; set => tratti = value; }
    Deck<Item> shop = new Deck<Item>("Interface/Shop/Object");
    public Deck<Item> Shop { get => shop; set => shop = value; }
    private float xVelocity = 10f;
    public float XVelocity { get => xVelocity; set => xVelocity = value; }
}
