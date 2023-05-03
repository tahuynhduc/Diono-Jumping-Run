using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Setting : MonoBehaviour
{
    SettingMusic music;
    public GameObject OffMusicButton;
    public GameObject OnMusicButton;
    public GameObject OffSoundButton;
    public GameObject OnSoundButton;
    public int checkSound;
    public int checkMusic;
    private void Start()
    {
        music = FindAnyObjectByType<SettingMusic>();
        checkSound = PlayerPrefs.GetInt("checkSound", checkSound);
        checkMusic = PlayerPrefs.GetInt("checkMusic", checkMusic);
        if (checkSound == 1)
        {
            OnSoundButton.SetActive(true);
            OffSoundButton.SetActive(false);
        }
        if (checkSound == 2)
        {
            OffSoundButton.SetActive(true);
            OnSoundButton.SetActive(false);
        }
        if(checkMusic == 1)
        {
            OnMusicButton.SetActive(true);
            OffMusicButton.SetActive(false);
        }
        if(checkMusic == 2)
        {
            OffMusicButton.SetActive(true);
            OnMusicButton.SetActive(false);
        }
    }
    public void OffMusic()
    {
        music.OffMusic();
        OffMusicButton.SetActive(false);
        OnMusicButton.SetActive(true);
        checkMusic = 1;
        PlayerPrefs.SetInt("checkMusic", checkMusic);
        PlayerPrefs.Save();
    }
    public void OnMusic()
    {
        music.OnMusic();
        OffMusicButton.SetActive(true);
        OnMusicButton.SetActive(false);
        checkMusic = 2;
        PlayerPrefs.SetInt("checkMusic", checkMusic);
        PlayerPrefs.Save();
    }
    public void OffSound()
    {
        OffSoundButton.SetActive(false);
        OnSoundButton.SetActive(true);
        music.OffSound();
        checkSound = 1;
        PlayerPrefs.SetInt("checkSound", checkSound);
        PlayerPrefs.Save();

    }
    public void OnSound()
    {
        OffSoundButton.SetActive(true);
        OnSoundButton.SetActive(false);
        music.OnSound();
        checkSound = 2;
        PlayerPrefs.SetInt("checkSound", checkSound);
        PlayerPrefs.Save();
    }

}
