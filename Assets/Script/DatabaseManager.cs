using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
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
        CheckCharacter,
        EndlessMode,
        NormalMode
    }

    // Generic method to save data to PlayerPrefs
    public static void SaveData<T>(DatabaseKey key, T data)
    {
        string keyString = key.ToString();
        string dataString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(keyString, dataString);
        PlayerPrefs.Save();
    }

    // Generic method to load data from PlayerPrefs
    public static T LoadData<T>(DatabaseKey key)
    {
        string keyString = key.ToString();
        if (PlayerPrefs.HasKey(keyString))
        {
            string dataString = PlayerPrefs.GetString(keyString);
            return JsonUtility.FromJson<T>(dataString);
        }
        else
        {
            return default(T);
        }
    }
    public void Shop()
    {
        bool check = true;
        SaveData(DatabaseKey.CheckShop, check);
    }
    public void Character()
    {
        bool check = false;
        SaveData(DatabaseKey.CheckShop, check);
        Debug.Log(check);
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
        SaveData(DatabaseKey.PlayerName, playerName);

        // Load player name
        string loadedPlayerName = LoadData<string>(DatabaseKey.PlayerName);
        Debug.Log("Player Name: " + loadedPlayerName);
    }
}
