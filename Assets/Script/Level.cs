using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] LevelData levelData;

    Action<LevelData> _callback;
    public static int level;
    
    public void SetLevel(LevelData levelData, Action<LevelData> callback)
    {
        this.levelData = levelData;
        _callback = callback;
    }
    public void Onclick()
    {
        _callback?.Invoke(levelData);
        level = levelData.level;
    }
}
[Serializable]
public class LevelData
{
    public float time;
    public int level;
    public bool unlocked;
}

