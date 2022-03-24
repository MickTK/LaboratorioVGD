using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Deck<T>
{    
    List<T> pool = new List<T>();
    List<T> active = new List<T>();
    public List<T> Pool { get => pool; set => pool = value; }
    public List<T> Active { get => active; set => active = value; }

    string path;
    public Deck(string path){

        this.path = path;
    }

    public void Init(){
        T[] card = Resources.LoadAll(path, typeof(T)).Cast<T>().ToArray();
        foreach (var item in card)
        {
            pool.Add(item);
        }
    }

    public T Draw(){

        if(!pool.Any()){ // se la lista è vuota
            Init();
        }

        int cardPos = (int) (Random.value * pool.Count);
        T card = pool[cardPos];
        pool.Remove(card);
        return card;
    }

    public T Pick(){

        if(!pool.Any()){ // se la lista è vuota
            Init();
        }

        int cardPos = (int) (Random.value * pool.Count);
        T card = pool[cardPos];
        return card;
    }
}
