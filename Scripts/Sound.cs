using UnityEngine.Audio;
using UnityEngine;

/* Classe utilizzata per descrivere gli attributi di un suono */

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;

    [Range(0f, 1f)]
    public float volume;
    [Range(1f, 1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
