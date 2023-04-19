using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMusic : MonoBehaviour
{
    public static SettingMusic instance;
    static AudioSource audioSource;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("audio/AudioManager/MusicGame");
        audioSource.Play();
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OffMusic()
    {
        audioSource.Stop();
    }
    public void OnMusic()
    {
        audioSource.Play();
    }
}
