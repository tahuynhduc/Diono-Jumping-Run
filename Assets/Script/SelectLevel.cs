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
        if (checkMap == 1)
        {
            if (unlockState <= 20)
            {
                levelTwo.interactable = false;
            }
            if (unlockState <= 40)
            {
                levelThree.interactable = false;
            }
            if (unlockState <= 60)
            {
                levelFour.interactable = false;
            }
            if (unlockState <= 80)
            {
                levelFive.interactable = false;
            }
        }
        if (checkMap == 2)
        {
            if (unlockState < 100)
            {
                levelOne.interactable = false;
            }
            if (unlockStateDesert <= 20)
            {
                levelTwo.interactable = false;
            }
            if (unlockStateDesert <= 40)
            {
                levelThree.interactable = false;
            }
            if (unlockStateDesert <= 60)
            {
                levelFour.interactable = false;
            }
            if (unlockStateDesert <= 80)
            {
                levelFive.interactable = false;
            }
        }
        if (checkMap == 3)
        {
            if (unlockStateDesert < 100)
            {
                levelOne.interactable = false;
            }
            if (unlockStateGraveyard <= 20)
            {
                levelTwo.interactable = false;
            }
            if (unlockStateGraveyard <= 40)
            {
                levelThree.interactable = false;
            }
            if (unlockStateGraveyard <= 60)
            {
                levelFour.interactable = false;
            }
            if (unlockStateGraveyard <= 80)
            {
                levelFive.interactable = false;
            }
        }
        if (checkMap == 4)
        {
            if (unlockStateGraveyard < 100)
            {
                levelOne.interactable = false;
            }
            if (unlockStateSnow <= 20)
            {
                levelTwo.interactable = false;
            }
            if (unlockStateSnow <= 40)
            {
                levelThree.interactable = false;
            }
            if (unlockStateSnow <= 60)
            {
                levelFour.interactable = false;
            }
            if (unlockStateSnow <= 80)
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
