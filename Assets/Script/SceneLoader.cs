using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
    }
    //public void LoadScene()
    public void LoadScene(string scene)
    {
        //GAME_SCENE scene = GAME_SCENE.ShopScene;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1.0f;
        SaveGame.SaveCoins(0);
    }
    public void Endless()
    {
        SaveGame.saveMode = 1;
    }
    public void Normal()
    {
        SaveGame.saveMode = 2;
    }
    public void LoadGameplay()
    {
        if (SaveGame.saveMode == 1)
        {
            LoadScene("GameplayEndless");
        }
        if (SaveGame.saveMode == 2)
        {
            LoadScene("SelectLevel");
        }
    }
    public void Shop()
    {
        SaveGame.loadshop = 1;
    }
    public void Character()
    {
        SaveGame.loadshop = 2;

    }
}
