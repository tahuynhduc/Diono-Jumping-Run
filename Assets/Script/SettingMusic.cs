using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMusic : MonoBehaviour
{
    static SettingMusic instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sound;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        sound.clip = Resources.Load<AudioClip>("audio/AudioManager/JumpAudio");
        music.clip = Resources.Load<AudioClip>("audio/AudioManager/MusicGame");
        music.Play();
        music.loop = true;
    }
    public void OffMusic()
    {
        music.Stop();
    }
    public void OnMusic()
    {
        music.Play();
    }
    public void OffSound()
    {
        sound.Stop();
    }
    public void OnSound()
    {
        sound.Play();
    }
}
