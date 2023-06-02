using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public static int checkSaveMap;
    public static int coinsGame;
    public static int checkShop;
    public static int removeAds;
    public static void SaveRemoveAds()
    {
        removeAds = 1;
        PlayerPrefs.SetInt("removeAds", removeAds);
        PlayerPrefs.Save();
    }
    public static void SaveMap()
    {
        PlayerPrefs.SetInt("checkSaveMap", checkSaveMap);
        PlayerPrefs.Save();
    }
    public static void LoadMap()
    {
        checkSaveMap = PlayerPrefs.GetInt("checkSaveMap", 0);
    }
    public static void Check()
    {
        PlayerPrefs.SetInt("checkShop", checkShop);
        PlayerPrefs.Save();
    }
    public static void Load()
    {
        checkShop = PlayerPrefs.GetInt("checkShop", 0);
    }
    #region coins game
    public static void BuyCoins(int value)
    {
        coinsGame += value;
        PlayerPrefs.SetInt("coinsGame",coinsGame);
        PlayerPrefs.Save();
    }
    public static void SaveCoins()
    {
        PlayerPrefs.SetInt("coinsGame", coinsGame);
        PlayerPrefs.Save();
    }
    public static void LoadCoins()
    {
        coinsGame = PlayerPrefs.GetInt("coinsGame", 0);
    }
    #endregion
}
