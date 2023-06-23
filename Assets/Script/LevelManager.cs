using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<Button> listBtn;
    [SerializeField] List<Level> level;
    [SerializeField] StageData stageData;
    [SerializeField] MapData mapData;
    [SerializeField] string defaultMap;
    private void Awake()
    {
        mapData = DatabaseManager.LoadData<MapData>(DatabaseManager.DatabaseKey.listMap, defaultMap);
        stageData = mapData.stages[SceneLoader.selectMap];
    }
    private void OnEnable()
    {
        ShowLevels();
    }
    public void ShowLevels()
    {
        for (int i = 0; i < stageData.levels.Count; i++)
        {
            if (stageData.levels[i].unlocked)
            {
                listBtn[i].interactable = stageData.levels[i].unlocked;
                level[i].SetLevel(stageData.levels[i], ChooseCharacter);
            }
        }
    }
    LevelData levelData;
    public void ChooseCharacter(LevelData levelData)
    {
        if (levelData.unlocked)
        {
            DatabaseManager.SaveData(DatabaseManager.DatabaseKey.TargetLevel, levelData);
            SceneManager.LoadScene("GameplayNormal");
        }
    }
    
}
[Serializable]
public class StageData
{
    public List<LevelData> levels;
    public int stage;
    public bool unlocked;
}

[Serializable]
public class MapData
{
    public List<StageData> stages;
}