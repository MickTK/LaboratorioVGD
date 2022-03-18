using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Deck<T>
{    
    List<T> deck = new List<T>();
    string path;
    public List<T> DeckAccess { get => deck; set => deck = value; }

    public Deck(string path){

        this.path = path;
    }

    public void Init(){
        T[] card = Resources.LoadAll(path, typeof(T)).Cast<T>().ToArray();
        foreach (var item in card)
        {
            deck.Add(item);
        }
    }

    public T Draw(){

        if(!deck.Any()){ // se la lista è vuota
            Init();
        }

        int cardPos = (int) (Random.value * deck.Count);
        T card = deck[cardPos];
        deck.Remove(card);
        return card;
    }

    public T Pick(){

        if(!deck.Any()){ // se la lista è vuota
            Init();
        }

        int cardPos = (int) (Random.value * deck.Count);
        T card = deck[cardPos];
        return card;
    }
}
