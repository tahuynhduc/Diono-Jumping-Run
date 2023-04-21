using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    UimanagerNormal ui;
    float check;
    int saveLevel;
    private void Awake()
    {
       ui = FindAnyObjectByType<UimanagerNormal>();
    }
    void Start()
    {
        check = PlayerPrefs.GetFloat("checkLevel", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkLevelOne()
    {
        SceneManager.LoadScene("GameplayNormal");
        check = 20;
        PlayerPrefs.SetFloat("checkLevel", check);
        PlayerPrefs.Save();
    }
    public void checkLevelTwo()
    {
        SceneManager.LoadScene("GameplayNormal");
        check = 40;
        PlayerPrefs.SetFloat("checkLevel", check);
        PlayerPrefs.Save();
    }
    public void checkLevelThree()
    {
        SceneManager.LoadScene("GameplayNormal");
        check = 60;
        PlayerPrefs.SetFloat("checkLevel", check);
        PlayerPrefs.Save();
    }
    public void checkLevelFor()
    {
        SceneManager.LoadScene("GameplayNormal");
        check = 80;
        PlayerPrefs.SetFloat("checkLevel", check);
        PlayerPrefs.Save();
    }
    public void checkLevelFive()
    {
        SceneManager.LoadScene("GameplayNormal");
        check = 100;
        PlayerPrefs.SetFloat("checkLevel", check);
        PlayerPrefs.Save();
    }
}
