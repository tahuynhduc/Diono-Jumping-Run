using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class GameControllerNormal : GameController
{
    [SerializeField] float timeCoins;
    private float spawnCoins;
    [SerializeField] string coin;
    List<GameObject> listCoins = new List<GameObject>();
    LevelData levelData;
    MapData mapData;
    StageData stageData;
    [SerializeField] string defaultMap;
    UimanagerNormal uimanagerNormal;
    public float target;
    public bool checkBuy;
    public bool unContinue;
    public bool gameOver = false;
    public bool pause = false;
    private void Start()
    {
        LoadData();
        ReferenceObject();
        LoadGameplay();
    }
    private void Update()
    {
        RandomCoins();
        RandomObstacle();
    }
    public void RandomCoins()
    {
        spawnCoins -= Time.deltaTime;
        if (spawnCoins <= 0)
        {
            CreateCoins();
            spawnCoins = timeCoins;
        }
    }
    private void CreateCoins()
    {
        GameObject coins = EasyObjectPool.instance.GetObjectFromPool(coin, new Vector3(Random.Range(20, 30), -6f, 0), Quaternion.identity);
        listCoins.Add(coins);
    }
    public void NextLevel()
    {
        Level.level++;
        for (int i = 0; i < stageData.levels.Count; i++)
        {
            if (Level.level >= stageData.levels.Count)
            {
                stageData = mapData.stages[SceneLoader.selectMap + 1];
                stageData.unlocked = true;
                stageData.levels[0].unlocked = true;
                DatabaseManager.SaveData(DatabaseManager.DatabaseKey.listMap, mapData);
                SceneManager.LoadScene("SelectMap");
            }
        }
        stageData.levels[Level.level].unlocked = true;
        SceneManager.LoadScene("GameplayNormal");
    }
    public void LoadGameplay()
    {
        for (int i = 0; i < stageData.levels.Count; i++)
        {
            if(stageData.levels[i].level == Level.level)
            {
                levelData = stageData.levels[Level.level];
            }
        }
        target = levelData.time;
    }
    private void LoadData()
    {
        checkBuy = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.RemoveAds);
        mapData = DatabaseManager.LoadData<MapData>(DatabaseManager.DatabaseKey.listMap, defaultMap);
        stageData = mapData.stages[SceneLoader.selectMap];
    }
    private void ReferenceObject()
    {
        uimanagerNormal = FindAnyObjectByType<UimanagerNormal>();
    }
    public void ContinueWith10Coins()
    {
        if (DatabaseManager.coinsGame >= 10 && unContinue == false)
        {
            DatabaseManager.coinsGame -= 10;
            unContinue = true;
            uimanagerNormal.continueButton();
        }
    }
}
