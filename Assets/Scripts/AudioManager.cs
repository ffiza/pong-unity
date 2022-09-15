using System;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Class <c>AudioManager</c> models a manager for audio tracks in the game.
/// </summary>
public class AudioManager : MonoBehaviour {
    /// <summary>
    /// Instance variable <c>sounds</c> contains a list of instances of the
    /// <c>Sound</c> class.
    /// </summary>
    public Sound[] sounds;

    void Awake() {
        // Add an AudioSource component for each sound in sounds.
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /// <summary>
    /// This method plays a sound given its name.
    /// </summary>
    /// <param><c>name</c> is the name of the sound to be played.</param>
    public void PlaySound(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    void Start() {
        // Play background music from the beginning of the scene.
        PlaySound("BackgroundMusic");
    }
}
