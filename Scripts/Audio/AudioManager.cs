using System;
using System.Collections.Generic;
using UnityEngine;

public partial class AudioManager : MonoBehaviour
{
    // Array che conterr� le informazioni sui suoni
    public Sound[] sounds;
    // Permette di far partire un suono all'avvio dello script specificandone l'indice
    public int startSoundIndex = -1;

    public bool musicOn = true;
    public bool effectOn = true;

    public static AudioManager instance;

    void Awake()
    {
        /* Persistenza dei suoni: permette di mantenere attivo un suono al cambio di scena  */
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        /* Inizializza i suoni nell'array */
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        // Fa partire il suono in automatico allo start
        if (startSoundIndex > -1)
            Play(sounds[startSoundIndex].clip.name);
    }

    // Metodo per far partire un suono
    public void Play(string name)
    {
        /* Cerca il suono nell'array e lo fa partire */
        Sound s = Array.Find(sounds, sound => sound.clip.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    // Metodo per interrompere un suono
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.clip.name == name);

        s.source.Stop();
    }

    // Metodo per modificare il volume dei suoni e della musica
    // type -> "Music" per modificare il volume della musica, "Sound" per i suoni di gioco
    public void SetVolume(float volume, string type)
    {
        foreach (Sound sound in sounds) 
        {
            if (type.ToLower() == "music" && sound.isSong)
            {
                sound.volume = volume;
            }
            else if (type.ToLower() == "sound" && !sound.isSong)
            {
                sound.volume = volume;
            }
        }
    }
}
