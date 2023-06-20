using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    SettingMusic settingMusic;
    public GameObject onMusic;
    public GameObject onSound;
    bool mucsicGame;
    bool soundGame;
    private void Awake()
    {
        mucsicGame = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.mucsicGame, mucsicGame.ToString());
        soundGame = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.soundGame, soundGame.ToString());
    }
    private void Start()
    {
        settingMusic = FindAnyObjectByType<SettingMusic>();
        MusicGame(mucsicGame);
        SoundGame(soundGame);
    }
    public void MusicGame(bool state)
    {
        mucsicGame = state;
        if (mucsicGame)
        {
            settingMusic.OnMusic();
            onMusic.SetActive(false);
            mucsicGame = true;
        }
        else
        {
            settingMusic.OffMusic();
            onMusic.SetActive(true);
            mucsicGame = false;
        }
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.mucsicGame, mucsicGame);
    }
    public void SoundGame(bool state)
    {
        soundGame = state;
        if (soundGame)
        {
            settingMusic.OnSound();
            onSound.SetActive(false);
            soundGame = true;
        }
        else
        {
            settingMusic.OffSound();
            onSound.SetActive(true);
            soundGame = false;
        }
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.soundGame, soundGame);
    }
}