using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public static bool checkMode;
    public static bool checkShop;
    public static int selectMap;
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        DatabaseManager.CoinsGame(0);
    }
    public void CheckMap(int value)
    {
        selectMap = value;
    }
    public void CheckShop(bool check)
    {
        checkShop = check;
    }
    public void CheckMode(bool check)
    {
        checkMode = check;
    }
    public void LoadGameplay()
    {

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
