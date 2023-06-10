using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UimanagerNormal : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject GameoverPanel, VictoriPanel;
    public Text CoinsText;
    public Slider Slider;
    public GameObject PopupAds;

    float unlockState;
    float unlockStateDesert;
    float unlockStateGraveyard;
    float unlockStateSnow;
    public float valueSlider;
    public float Timedown;
    private bool gameOver = false;
    private bool pause = false;
    InterstitialAdExample interstitialAdExample;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        unlockState = PlayerPrefs.GetFloat("unlockState", unlockState);
        unlockStateDesert = PlayerPrefs.GetFloat("unlockStateDesert", unlockStateDesert);
        unlockStateGraveyard = PlayerPrefs.GetFloat("unlockStateGraveyard", unlockStateGraveyard);
        unlockStateSnow = PlayerPrefs.GetFloat("unlockStateSnow", unlockStateSnow);
        valueSlider = PlayerPrefs.GetFloat("valueSlider", valueSlider);
        interstitialAdExample = FindAnyObjectByType<InterstitialAdExample>();
        Slider.maxValue = valueSlider;
        Slider.value = valueSlider;
        Slider.minValue = 0;
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
        CoinsText.text = SaveGame.coinsGame.ToString();
    }
    public void ShowPopup()
    {
        Time.timeScale = 0;
        if (interstitialAdExample.unContinue)
            PopupAds.SetActive(false);
        else
            PopupAds.SetActive(true);
    }
    public void HidenPopup()
    {
        PopupAds.SetActive(false);
    }
    public void ContinueWith10Coins()
    {
        if (SaveGame.coinsGame >= 10 && interstitialAdExample.unContinue == false)
        {
            SaveGame.coinsGame = SaveGame.coinsGame - 10;
            interstitialAdExample.unContinue = true;
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
        PopupAds.SetActive(false);
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
        valueSlider += 20;
        PlayerPrefs.SetFloat("valueSlider", valueSlider);
        if (SaveGame.checkmap == 1 && unlockState < valueSlider)
        {
            unlockState = valueSlider;
            PlayerPrefs.SetFloat("unlockState", unlockState);
        }
        if (SaveGame.checkmap == 2 && unlockStateDesert < valueSlider)
        {
            unlockStateDesert = valueSlider;
            PlayerPrefs.SetFloat("unlockStateDesert", unlockStateDesert);
        }
        if (SaveGame.checkmap == 3 && unlockStateGraveyard < valueSlider)
        {
            unlockStateGraveyard = valueSlider;
            PlayerPrefs.SetFloat("unlockStateGraveyard", unlockStateGraveyard);
        }
        if (SaveGame.checkmap == 4 && unlockStateSnow < valueSlider)
        {
            unlockStateSnow = valueSlider;
            PlayerPrefs.SetFloat("unlockStateSnow", unlockStateSnow);
        }
        PlayerPrefs.Save();
    }
    #endregion
}