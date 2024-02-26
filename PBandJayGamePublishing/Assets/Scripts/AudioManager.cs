using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] music;
    //public Sounds[] sfx;
    public AudioSource musicSource;
    //public AudioSource sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Background Music");
    }
    public void PlayMusic(string name)
    {
        Sounds sound = Array.Find(music, x => x.name == name);

        musicSource.clip = sound.clip;
        musicSource.Play();
    }
}