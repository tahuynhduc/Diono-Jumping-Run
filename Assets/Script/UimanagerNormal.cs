using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UimanagerNormal : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject GameoverPanel, VictoriPanel;
    [SerializeField] TextMeshProUGUI CoinsText;
    [SerializeField] Slider Slider;
    [SerializeField] GameObject PopupAds;
    InterstitialAdExample interstitialAdExample;
    GameControllerNormal gameControllerNormal;

    private void Start()
    {
        ReferenceObject();
    }

    private void ReferenceObject()
    {
        interstitialAdExample = FindAnyObjectByType<InterstitialAdExample>();
        gameControllerNormal = FindAnyObjectByType<GameControllerNormal>();
        Slider.maxValue = gameControllerNormal.target;
        Slider.value = gameControllerNormal.target;
        Slider.minValue = 0;
    }

    void Update()
    {
        ShowCoinsText();
        ShowStateGameplay();
    }
    private void ShowStateGameplay()
    {
        Slider.value -= Time.deltaTime;
        if (Slider.value <= 0)
        {
            gameControllerNormal.StateGame(0);
            VictoriPanel.SetActive(true);
        }
    }

    public void ShowCoinsText()
    {
        CoinsText.text = DatabaseManager.coinsGame.ToString();
    }
    public void ShowPopup()
    {
        if (gameControllerNormal.unContinue)
            PopupAds.SetActive(false);
        else
            PopupAds.SetActive(true);
    }
   
    public void hidenPopup()
    {
        PopupAds.SetActive(false);
    }
    public void SkipAd()
    {
        if (gameControllerNormal.unContinue == false)
        {
            gameControllerNormal.unContinue = true;
            hidenPopup();
            if (gameControllerNormal.checkBuy == false)
            {
                interstitialAdExample.ShowAd();
            }
            continueButton();
        }
    }
    #region state game
    public void ShowGameOver()
    {
        gameControllerNormal.StateGame(0);
        pauseButton.SetActive(false);
        GameoverPanel.SetActive(true);
    }
    public void ShowPauseButton()
    {
        gameControllerNormal.StateGame(0);
        pausePanel.SetActive(true);
    }
    public void replayButton()
    {
        gameControllerNormal.gameOver = false;
        GameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameControllerNormal.pause = false;
        SceneManager.LoadScene("GameplayNormal");
    }
    public void continueButton()
    {
        hidenPopup();
        gameControllerNormal.StateGame(1);
        gameControllerNormal.gameOver = false;
        GameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        gameControllerNormal.pause = false;
    }
    #endregion
}