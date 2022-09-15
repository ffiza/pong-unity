using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Class <c>Sound</c> models a sound with its main properties.
/// </summary>
[System.Serializable]
public class Sound {
    // Audio clip.
    public AudioClip clip;

    // Name to be used as reference.
    public string name;

    // Volume of the clip.
    [Range(0f, 1f)]
    public float volume = 1f;

    // Pitch of the clip.
    [Range(.1f, 3f)]
    public float pitch = 1f;

    // AudioSource of the sound.
    [HideInInspector]
    public AudioSource source;

    // Loop state of the sound.
    public bool loop;
}
