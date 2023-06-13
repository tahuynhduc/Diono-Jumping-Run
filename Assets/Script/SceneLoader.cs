using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    //public void LoadScene()
    public void LoadScene(string scene)
    {
        //GAME_SCENE scene = GAME_SCENE.ShopScene;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1.0f;
        SaveGame.SaveCoins(0);
    }
    public void CheckMap(int value)
    {
        int checkMap = value;
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.SaveMap,checkMap);
    }
    public void LoadGameplay()
    {
        bool checkMode = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CheckMode);
        if (checkMode)
        {
            LoadScene("GameplayEndless");
        }
        if (checkMode == false)
        {
            LoadScene("SelectLevel");
        }
    }
}
