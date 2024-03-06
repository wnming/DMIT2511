using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] music;
    //public Sounds[] sfx;
    public AudioSource musicSource;
    //public AudioSource sfxSource;

    bool isMuted = false;
    public GameObject muteImage;
    public GameObject musicImage;
    public Slider musicSlider;
    public GameObject optionsMenu;

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
        muteImage.SetActive(false);
        musicImage.SetActive(true);
        musicSlider.value = 1;
        optionsMenu.SetActive(false);
    }
    public void PlayMusic(string name)
    {
        Sounds sound = Array.Find(music, x => x.name == name);

        musicSource.clip = sound.clip;
        musicSource.Play();
    }
    public void Mute()
    {
        //musicSource.mute = !musicSource.mute;
        isMuted = !isMuted;

        if (isMuted)
        {
            musicSource.volume = 0f;
            muteImage.SetActive(true);
            musicImage.SetActive(false);
            musicSlider.interactable = false;
        }
        else
        {
            musicSource.volume = 1f;
            muteImage.SetActive(false);
            musicImage.SetActive(true);
            musicSlider.interactable = true;
        }
    }
    public void VolumeController(float volume)
    {
        musicSource.volume = volume;
    }
    public void MusicVolume()
    {
        instance.VolumeController(musicSlider.value);
    }
    public void ToggleOptionsMenu()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
    public void BackToMenu()
    {
        ToggleOptionsMenu();
    }
}