using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    float TargetLevel;
    float unlockState;
    float unlockStateDesert;
    float unlockStateGraveyard;
    float unlockStateSnow;
    int checkMap;
    [SerializeField] Button levelOne;
    [SerializeField] Button levelTwo;
    [SerializeField] Button levelThree;
    [SerializeField] Button levelFour;
    [SerializeField] Button levelFive;
    private void Awake()
    {
        checkMap = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.SaveMap);
        TargetLevel = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.TargetLevel);
        unlockState = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockState);
        unlockStateDesert = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockStateDesert);
        unlockStateGraveyard = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockStateGraveyard);
        unlockStateSnow = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockStateSnow);
    }
    void Start()
    {
        State();
    }

    private void State()
    {
        CheckUnlockLevel(1, float.MaxValue, unlockState);
        CheckUnlockLevel(2, unlockState, unlockStateDesert);
        CheckUnlockLevel(3,unlockStateDesert, unlockStateGraveyard);
        CheckUnlockLevel(4,unlockStateGraveyard, unlockStateSnow);
    }
    private void CheckUnlockLevel(int map,float preCondition, float currentState)
    {
        if (checkMap == map)
        {
            levelOne.interactable = preCondition >= 100;
            if (currentState <= 20)
            {
                levelTwo.interactable = false;
            }
            if (currentState <= 40)
            {
                levelThree.interactable = false;
            }
            if (currentState <= 60)
            {
                levelFour.interactable = false;
            }
            if (currentState <= 80)
            {
                levelFive.interactable = false;
            }
        }
    }
    public void CheckLevel(float value)
    {
        SceneManager.LoadScene("GameplayNormal");
        TargetLevel = value;
        if (unlockState <= TargetLevel)
        {
            unlockState = TargetLevel;
        }
        if (unlockStateDesert < TargetLevel && unlockState >= 100)
        {
            unlockStateDesert = TargetLevel;
        }
        if (unlockStateGraveyard < TargetLevel && unlockStateDesert >= 100)
        {
            unlockStateGraveyard = TargetLevel;
        }
        if (unlockStateSnow < TargetLevel && unlockStateGraveyard >= 100)
        {
            unlockStateSnow = TargetLevel;
        }
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.TargetLevel, TargetLevel);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockState, unlockState);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockStateDesert, unlockStateDesert);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockStateGraveyard, unlockStateGraveyard);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockStateSnow, unlockStateSnow);
    }
}
