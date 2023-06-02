using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    float valueSlider;
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
        valueSlider = PlayerPrefs.GetFloat("valueSlider", 0);
        unlockState = PlayerPrefs.GetFloat("unlockState", 0);
        checkMap = PlayerPrefs.GetInt("checkmap", 0);
        unlockStateDesert = PlayerPrefs.GetInt("unlockStateDesert", 0);
        unlockStateGraveyard = PlayerPrefs.GetInt("unlockStateGraveyard",0);
        unlockStateSnow = PlayerPrefs.GetInt("unlockStateSnow",0);
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

    public void checkLevelOne()
    {
        SceneManager.LoadScene("GameplayNormal");
        valueSlider = 20;
        PlayerPrefs.SetFloat("valueSlider", valueSlider);
        PlayerPrefs.Save();
        if(unlockState < valueSlider)
        {
            unlockState = valueSlider;
            PlayerPrefs.SetFloat("unlockState", unlockState);
            PlayerPrefs.Save();
        }
        if (unlockStateDesert < valueSlider && unlockState >= 100)
        {
            unlockStateDesert = valueSlider;
            PlayerPrefs.SetFloat("unlockStateDesert", unlockStateDesert);
            PlayerPrefs.Save();
        }
        if (unlockStateGraveyard < valueSlider && unlockStateDesert >= 100)
        {
            unlockStateGraveyard = valueSlider;
            PlayerPrefs.SetFloat("unlockStateGraveyard", unlockStateGraveyard);
            PlayerPrefs.Save();
        }
        if (unlockStateSnow < valueSlider && unlockStateGraveyard >= 100)
        {
            unlockStateSnow = valueSlider;
            PlayerPrefs.SetFloat("unlockStateSnow", unlockStateSnow);
            PlayerPrefs.Save();
        }
    }
    public void checkLevelTwo()
    {
        SceneManager.LoadScene("GameplayNormal");
        valueSlider = 40;
        PlayerPrefs.SetFloat("valueSlider", valueSlider);
        PlayerPrefs.Save();
        if (unlockState < valueSlider)
        {
            unlockState = valueSlider;
            PlayerPrefs.SetFloat("unlockState", unlockState);
            PlayerPrefs.Save();
        }
        if (unlockStateDesert < valueSlider && unlockState >= 100)
        {
            unlockStateDesert = valueSlider;
            PlayerPrefs.SetFloat("unlockStateDesert", unlockStateDesert);
            PlayerPrefs.Save();
        }
        if (unlockStateGraveyard < valueSlider && unlockStateDesert >= 100)
        {
            unlockStateGraveyard = valueSlider;
            PlayerPrefs.SetFloat("unlockStateGraveyard", unlockStateGraveyard);
            PlayerPrefs.Save();
        }
        if (unlockStateSnow < valueSlider && unlockStateGraveyard >= 100)
        {
            unlockStateSnow = valueSlider;
            PlayerPrefs.SetFloat("unlockStateSnow", unlockStateSnow);
            PlayerPrefs.Save();
        }
    }
    public void checkLevelThree()
    {
        SceneManager.LoadScene("GameplayNormal");
        valueSlider = 60;
        PlayerPrefs.SetFloat("valueSlider", valueSlider);
        PlayerPrefs.Save();
        if (unlockState < valueSlider && unlockState >= 100)
        {
            unlockState = valueSlider;
            PlayerPrefs.SetFloat("unlockState", unlockState);
            PlayerPrefs.Save();
        }
        if (unlockStateDesert < valueSlider)
        {
            unlockStateDesert = valueSlider;
            PlayerPrefs.SetFloat("unlockStateDesert", unlockStateDesert);
            PlayerPrefs.Save();
        }
        if (unlockStateGraveyard < valueSlider && unlockStateDesert >= 100)
        {
            unlockStateGraveyard = valueSlider;
            PlayerPrefs.SetFloat("unlockStateGraveyard", unlockStateGraveyard);
            PlayerPrefs.Save();
        }
        if (unlockStateSnow < valueSlider && unlockStateGraveyard >= 100)
        {
            unlockStateSnow = valueSlider;
            PlayerPrefs.SetFloat("unlockStateSnow", unlockStateSnow);
            PlayerPrefs.Save();
        }
    }
    public void checkLevelFor()
    {
        SceneManager.LoadScene("GameplayNormal");
        valueSlider = 80;
        PlayerPrefs.SetFloat("valueSlider", valueSlider);
        PlayerPrefs.Save();
        if (unlockState < valueSlider)
        {
            unlockState = valueSlider;
            PlayerPrefs.SetFloat("unlockState", unlockState);
            PlayerPrefs.Save();
        }
        if (unlockStateDesert < valueSlider && unlockState >=100)
        {
            unlockStateDesert = valueSlider;
            PlayerPrefs.SetFloat("unlockStateDesert", unlockStateDesert);
            PlayerPrefs.Save();
        }
        if (unlockStateGraveyard < valueSlider && unlockStateDesert >= 100)
        {
            unlockStateGraveyard = valueSlider;
            PlayerPrefs.SetFloat("unlockStateGraveyard", unlockStateGraveyard);
            PlayerPrefs.Save();
        }
        if (unlockStateSnow < valueSlider && unlockStateGraveyard >= 100)
        {
            unlockStateSnow = valueSlider;
            PlayerPrefs.SetFloat("unlockStateSnow", unlockStateSnow);
            PlayerPrefs.Save();
        }
    }
    public void checkLevelFive()
    {
        SceneManager.LoadScene("GameplayNormal");
        valueSlider = 100;
        PlayerPrefs.SetFloat("valueSlider", valueSlider);
        PlayerPrefs.Save();
        if (unlockState < valueSlider)
        {
            unlockState = valueSlider;
            PlayerPrefs.SetFloat("unlockState", unlockState);
            PlayerPrefs.Save();
        }
        if (unlockStateDesert < valueSlider && unlockState >= 100)
        {
            unlockStateDesert = valueSlider;
            PlayerPrefs.SetFloat("unlockStateDesert", unlockStateDesert);
            PlayerPrefs.Save();
        }
        if (unlockStateGraveyard < valueSlider && unlockStateDesert >= 100)
        {
            unlockStateGraveyard = valueSlider;
            PlayerPrefs.SetFloat("unlockStateGraveyard", unlockStateGraveyard);
            PlayerPrefs.Save();
        }
        if (unlockStateSnow < valueSlider && unlockStateGraveyard >= 100)
        {
            unlockStateSnow = valueSlider;
            PlayerPrefs.SetFloat("unlockStateSnow", unlockStateSnow);
            PlayerPrefs.Save();
        }
    }
}
