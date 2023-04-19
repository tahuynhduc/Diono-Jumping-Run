using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    SettingMusic demo;
    public GameObject OffMusicButton;
    public GameObject OnMusicButton;
    Player player;
    public GameObject OffSoundButton;
    public GameObject OnSoundButton;
    private void Start()
    {
        demo = FindAnyObjectByType<SettingMusic>();
        player = FindAnyObjectByType<Player>();
    }
    private void Update()
    {
       
    }
    public void OffMusic()
    {
        demo.OffMusic();
        OffMusicButton.SetActive(false);
        OnMusicButton.SetActive(true);
    }
    public void OnMusic()
    {
        demo.OnMusic();
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
