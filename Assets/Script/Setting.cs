using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    SettingMusic music;
    public GameObject OffMusicButton;
    public GameObject OnMusicButton;
    SettingMusic player;
    public GameObject OffSoundButton;
    public GameObject OnSoundButton;
    private void Start()
    {
        music = FindAnyObjectByType<SettingMusic>();
        player = FindAnyObjectByType<SettingMusic>();
    }
    private void Update()
    {
       
    }
    public void OffMusic()
    {
        music.OffMusic();
        OffMusicButton.SetActive(false);
        OnMusicButton.SetActive(true);
    }
    public void OnMusic()
    {
        music.OnMusic();
        OffMusicButton.SetActive(true);
        OnMusicButton.SetActive(false);
    }
    public void OffSound()
    {
        OffSoundButton.SetActive(false);
        OnSoundButton.SetActive(true);
    }
    public void OnSound()
    {
        OffSoundButton.SetActive(true);
        OnSoundButton.SetActive(false);
    }

}
