using UnityEngine;

// Informazione relative ad un suono
[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public bool loop;

    // false -> suono, true -> musica
    // Utilizzato per modificare il volume
    public bool isSong = false;

    [Range(0f, 1f)]
    public float volume;
    [Range(1f, 1f)]
    public float pitch;

    // Attributo inizializzato dall'audio manager
    [HideInInspector]
    public AudioSource source;
}
