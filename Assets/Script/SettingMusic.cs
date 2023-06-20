using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMusic : MonoBehaviour
{
    static SettingMusic instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sound;
    SettingController settingController;
    bool mucsicGame;
    bool soundGame;
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
        mucsicGame = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.mucsicGame,mucsicGame.ToString());
        soundGame = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.soundGame, soundGame.ToString());
        MusicGame();
        SoundGame();
    }

    private void SoundGame()
    {
        if (soundGame == false)
        {
            OffSound();
        }
        else
        {
            OnSound();
        }
    }

    private void MusicGame()
    {
        if (mucsicGame == false)
        {
            OffMusic();
        }
        else
        {
            OnMusic();
            music.loop = true;
        }
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
