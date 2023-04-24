using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    SaveGame SaveGame;
    private void Awake()
    {
        SaveGame = FindObjectOfType<SaveGame>();
        
    }
    private void Start()
    {
    }
   
    //public void LoadScene()
    public void LoadScene(string scene)
    {
        //GAME_SCENE scene = GAME_SCENE.ShopScene;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1.0f;
    }
    public void Endless()
    {
        SaveGame.checkSaveMap = 1;
        SaveGame.SaveMap();
    }
    public void Normal()
    {
        SaveGame.checkSaveMap = 2;
        SaveGame.SaveMap();
    }
    public void LoadGameplay()
    {
        SaveGame.LoadMap();
        if (SaveGame.checkSaveMap == 1)
        {
            SceneManager.LoadScene("GameplayEndless");
        }
        if (SaveGame.checkSaveMap == 2)
        {
            SceneManager.LoadScene("SelectLevel");
        }
    }
    public void Shop()
    {
        SaveGame.checkShop = 1;
        SaveGame.Check();
    }
    public void Character()
    {
        SaveGame.checkShop = 2;
        SaveGame.Check();
    }
}
