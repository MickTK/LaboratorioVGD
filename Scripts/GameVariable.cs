using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariable : MonoBehaviour
{
    public bool isGameRunning; //quando questa variabile è falsa, i counter del gioco si fermano.
    public bool openShop = false; //quando questa variabile è true si apre lo shop nel gioco
    public bool invincible = false;
    public int difficolta; // 0 = facile, 1 = normale, 2 = difficile, 3 = hardcore
    public Transform player;
    public int monete;
    public int moltiplicatoreMonete = 1; //quando prendi delle monete le moltiplica secondo questo valore
    public int doni; // oggetti che ruotano che puoi trovare per la strada, power up
    public int vite;
    public int coroneOro; //le corone servono solo al calcolo dei punteggi del gioco
    public int buyedItems = 0; //quanti item hai comprato
    Deck<Tratto> tratti = new Deck<Tratto>("Interface/Tratto/Object"); //lista completa dei tratti
    public Deck<Tratto> Tratti { get => tratti; set => tratti = value; }
    Deck<Item> shop = new Deck<Item>("Interface/Shop/Object"); //lista completa oggetti
    public Deck<Item> Shop { get => shop; set => shop = value; }
    public float xSpeed = 20f; //velocità laterale di movimento del personaggio
    public float ySpeed = 15f; //velocità verticale di movimento del personaggio e degli oggetti
    public float obstacleWaitTime = 2f; //quanti secondi ci sono tra una riga di oggetti e l'altra
    public int giftsSpawnRate = 7; //ogni 7 righe spawna un regalo
    public int shopSpawnRate = 30; //ogni 30 righe spawna uno shop
    public float jumpForce = 5f; //forza di salto
    public float gravity = 9.81f;
    public int punteggio; //punteggio attuale del giocatore
}
