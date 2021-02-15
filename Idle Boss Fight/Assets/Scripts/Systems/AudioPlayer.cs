using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource backgroundMusicSource;
    [SerializeField]
    private AudioClip attackSound;

    public static AudioPlayer Instance;

    public bool isMuted = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void Play(AudioClip clip) => audioSource.PlayOneShot(clip);

    public void ToggleAudioMute(bool value)
    {
        isMuted = value;
        audioSource.mute = isMuted;
        backgroundMusicSource.mute = isMuted;
    }
}
