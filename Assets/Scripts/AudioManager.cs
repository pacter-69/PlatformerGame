using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip[] sounds, music;
    public AudioSource soundsSource, musicSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        PlayMusic("GameMusic");
    }

    public void PlayMusic(string name)
    {
        AudioClip s = Array.Find(music, s => s.name == name);
        if (s != null)
        {
            musicSource.clip = s;
            musicSource.Play();
        }
    }
    public void PlaySound(string name)
    {
        AudioClip s = Array.Find(sounds, s => s.name == name);
        if (s != null)
        {
            soundsSource.PlayOneShot(s);
        }
    }
}
