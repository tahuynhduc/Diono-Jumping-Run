using System;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static int coinsGame;
    private void Start()
    {
        bool loadedHighScore = LoadData<bool>(DatabaseKey.CheckShop);
        Debug.Log("High Score: " + loadedHighScore);

    }
    // Enum to define the keys for PlayerPrefs
    public enum DatabaseKey
    {
        HighScore,
        PlayerName,
        GameLevel,
        RemoveAds,
        CheckShop,
        CheckMode,
        CoinsGame,
        SaveMap,
        BestScore,
        TargetLevel,
        unlockState,
        unlockStateDesert,
        unlockStateGraveyard,
        unlockStateSnow,
        chooseCharacter,
        characterListData
    }

    // Generic method to save data to PlayerPrefs
    public static void SaveData<T>(DatabaseKey key, T data)
    {
        string keyString = key.ToString();
        string dataString = string.Empty;
        var datatType = typeof(T);
        if (datatType.IsPrimitive || datatType == typeof(string))
        {
            dataString = data.ToString();
        }
        else
        {
            dataString = JsonUtility.ToJson(data);
        }
        PlayerPrefs.SetString(keyString, dataString);
        PlayerPrefs.Save();
        Debug.Log($"Save: {keyString}: {dataString}");
    }
    // Generic method to load data from PlayerPrefs
    public static T LoadData<T>(DatabaseKey key, string defaultValue = "")
    {
        string keyString = key.ToString();
        string dataString = PlayerPrefs.GetString(keyString, defaultValue);
        if (PlayerPrefs.HasKey(keyString) || !string.IsNullOrEmpty(dataString))
        {
            Debug.Log($"Load: {keyString}: {dataString}");
            var datatType = typeof(T);
            if (datatType.IsPrimitive || datatType == typeof(string))
            {
                Debug.Log($"string data: {dataString}");
                return (T)Convert.ChangeType(dataString, typeof(T));
            }
            else
            {
                return JsonUtility.FromJson<T>(dataString);
            }
        }
        else
        {
            Debug.Log($"Load: {keyString}: default");
            return default(T);
        }
    }
    public static void CoinsGame(int value)
    {
        coinsGame += value;
        SaveData(DatabaseKey.CoinsGame, coinsGame);
    }
    public void Shop()
    {
        bool shop = true;
        SaveData(DatabaseKey.CheckShop, shop);
    }
    public void Character()
    {
        bool character = false;
        SaveData(DatabaseKey.CheckShop, character);
    }
    public void Endless()
    {
        bool endless = true;
        SaveData(DatabaseKey.CheckMode, endless);
    }
    public void Normal()
    {
        bool normal = false;
        SaveData(DatabaseKey.CheckMode, normal);
    }
    public void SaveRemoveAds()
    {
        bool removeAds = true;
        SaveData(DatabaseKey.RemoveAds, removeAds);
    }
    // Example usage
    public static void ExampleUsage()
    {
        // Save high score
        int highScore = 1000;
        SaveData(DatabaseKey.HighScore, highScore);

        // Load high score
        int loadedHighScore = LoadData<int>(DatabaseKey.HighScore);
        Debug.Log("High Score: " + loadedHighScore);

        // Save player name
        string playerName = "John Doe";
        //SaveData(DatabaseKey.PlayerName, playerName);

        // Load player name
        string loadedPlayerName = LoadData<string>(DatabaseKey.PlayerName);
        Debug.Log("Player Name: " + loadedPlayerName);
    }
}
