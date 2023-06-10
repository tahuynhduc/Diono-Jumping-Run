using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public static int saveMode;
    public static int coinsGame;
    public static int removeAds;
    public static int loadshop;
    public static int checkmap;
    public static void SaveRemoveAds()
    {
        removeAds = 1;
        PlayerPrefs.SetInt("removeAds", removeAds);
        PlayerPrefs.Save();
    }
    #region coins game
    public static void SaveCoins(int value)
    {
        coinsGame += value;
        PlayerPrefs.SetInt("coinsGame",coinsGame);
        PlayerPrefs.Save();
    }
    #endregion
}
