using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiSettings : MonoBehaviour
{
    SettingMusic settingMusic;
    [SerializeField] GameObject onMusic;
    [SerializeField] GameObject onSound;
    private void Awake()
    {
        ReferenceObject();
    }

    private void ReferenceObject()
    {
        settingMusic = FindAnyObjectByType<SettingMusic>();
    }

    private void Start()
    {
        MusicGame(settingMusic.musicGame);
        SoundGame(settingMusic.soundGame);
    }
    public void MusicGame(bool state)
    {
        if (state)
        {
            settingMusic.OnMusic();
            onMusic.SetActive(false);
        }
        else
        {
            settingMusic.OffMusic();
            onMusic.SetActive(true);
        }
        settingMusic.SaveAudio(state);
    }
    public void SoundGame(bool state)
    {
        if (state)
        {
            settingMusic.OnSound();
            onSound.SetActive(false);
        }
        else
        {
            settingMusic.OffSound();
            onSound.SetActive(true);
        }
        settingMusic.SaveAudio(state);

    }
}