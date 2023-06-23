using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMusic : MonoBehaviour
{
    static SettingMusic instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sound;
    public bool musicGame;
    public bool soundGame;
    [SerializeField] string defaultMusic;
    [SerializeField] string defaultSound;

    private void Awake()
    {
        LoadData();
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
        MusicGame();
        SoundGame();
    }

    private void LoadData()
    {
        musicGame = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.mucsicGame,defaultMusic);
        soundGame = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.soundGame,defaultSound);
        sound.clip = Resources.Load<AudioClip>("audio/AudioManager/JumpAudio");
        music.clip = Resources.Load<AudioClip>("audio/AudioManager/MusicGame");
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
        if (musicGame == false)
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
    public void SaveAudio(bool audio)
    {
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.mucsicGame, musicGame);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.soundGame, soundGame);
    }
}
