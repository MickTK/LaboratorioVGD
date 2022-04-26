using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariable : MonoBehaviour
{
    public bool isGameRunning;
    //TODO IMPLEMENTA
    public byte difficolta; // 0 = facile, 1 = normale, 2 = difficile, 3 = hardcore
    public Transform player;
    public int monete;
    //TODO IMPLEMENTA I COLLEGAMENTI 
    public int doni; // oggetti che ruotano che puoi trovare per la strada, power up
    public int punteggio;
    public byte vite;
    public byte viteMassime;
    public byte viteNonRecuperabili;
    Deck<Tratto> tratti = new Deck<Tratto>("Interface/Tratto/Object");
    public Deck<Tratto> Tratti { get => tratti; set => tratti = value; }
    Deck<Item> shop = new Deck<Item>("Interface/Shop/Object");
    public Deck<Item> Shop { get => shop; set => shop = value; }
    public float xVelocity = 10f;
}
