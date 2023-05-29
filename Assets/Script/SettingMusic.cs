using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMusic : MonoBehaviour
{
    static SettingMusic instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sound;
    Setting setting;
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
        if (setting.checkMusic == 1)
        {
            setting.OffMusic();
        }
        if (setting.checkMusic == 2)
        {
            setting.OnMusic();
        }
        if (setting.checkSound == 1)
        {
            setting.OffSound();
        }
        if (setting.checkSound == 2)
        {
            setting.OnSound();
        }
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
