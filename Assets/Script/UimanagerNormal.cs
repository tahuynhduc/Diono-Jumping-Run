using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UimanagerNormal : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject GameoverPanel, VictoriPanel;
    public TextMeshProUGUI CoinsText;
    public Slider Slider;
    public GameObject PopupAds;

    float unlockState;
    float unlockStateDesert;
    float unlockStateGraveyard;
    float unlockStateSnow;
    public float TargetLevel;
    public float Timedown;
    private bool gameOver = false;
    private bool pause = false;
    bool unContinue;
    InterstitialAdExample interstitialAdExample;

    // Start is called before the first frame update
    private void Awake()
    {
        TargetLevel = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.TargetLevel);
        unlockState =DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockState);
        unlockStateDesert =DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockStateDesert);
        unlockStateGraveyard = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockStateGraveyard);
        unlockStateSnow = DatabaseManager.LoadData<float>(DatabaseManager.DatabaseKey.unlockStateSnow);
        interstitialAdExample = FindAnyObjectByType<InterstitialAdExample>();
        Slider.maxValue = TargetLevel;
        Slider.value = TargetLevel;
        Slider.minValue = 0;
        Time.timeScale = 1;
    }
    void Update()
    {
        ShowCoinsText();
        Slider.value -= Time.deltaTime;
        if (Slider.value <= 0)
        {
            Time.timeScale = 0;
            VictoriPanel.SetActive(true);
        }
        if (pause)
        {
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            pauseButton.SetActive(false);
        }
    }
    public void ShowCoinsText()
    {
        CoinsText.text = DatabaseManager.coinsGame.ToString();
    }
    public void ShowPopup()
    {
        if (unContinue)
            PopupAds.SetActive(false);
        else
            PopupAds.SetActive(true);
    }
    public void ContinueWith10Coins()
    {
        if (DatabaseManager.coinsGame >= 10 && unContinue == false)
        {
            DatabaseManager.coinsGame -= 10;
            unContinue = true;
            continueButton();
        }
    }
    public void hidenPopup()
    {
        PopupAds.SetActive(false);
    }
    public void SkipAd()
    {
        if (unContinue == false)
        {
            bool checkBuy = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.RemoveAds);
            unContinue = true;
            hidenPopup();
            if (checkBuy == false)
            {
                interstitialAdExample.ShowAd();
            }
            continueButton();
        }
    }
    #region state game

    public void ShowGameOver()
    {
        GameoverPanel.SetActive(true);
        gameOver = true;
    }
    public void ShowPauseButton()
    {
        pausePanel.SetActive(true);
        pause = true;
    }
    public void replayButton()
    {
        SceneManager.LoadScene("GameplayNormal");
        gameOver = false;
        GameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
    }
    public void continueButton()
    {
        hidenPopup();
        Time.timeScale = 1;
        gameOver = false;
        GameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        pause = false;
    }
    public void NextButton()
    {
        SceneManager.LoadScene("GameplayNormal");
        TargetLevel += 20;
        int checkMap = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.SaveMap);
        switch (checkMap)
        {
            case 1:
                if (unlockState < TargetLevel)
                    unlockState = TargetLevel;
                break;
            case 2:
                if (unlockStateDesert < TargetLevel)
                    unlockStateDesert = TargetLevel;
                break;
            case 3:
                if (unlockStateGraveyard < TargetLevel)
                    unlockStateGraveyard = TargetLevel;
                break;
            case 4:
                if (unlockStateSnow < TargetLevel)
                    unlockStateSnow = TargetLevel;
                break;
        }
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.TargetLevel, TargetLevel);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockState, unlockState);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockStateDesert, unlockStateDesert);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockStateGraveyard, unlockStateGraveyard);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.unlockStateSnow, unlockStateSnow);
    }
    #endregion
}