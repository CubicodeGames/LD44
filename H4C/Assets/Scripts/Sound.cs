using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [HideInInspector] public AudioSource source;

    [Range(0f, 1f)]
    public float volume = .8f;
    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;
}
