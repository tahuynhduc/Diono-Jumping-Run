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
    public GameObject GameoverPanel,VictoriPanel;
    public Text CoinsText;
    public Slider Slider;
    SaveGame SaveGame;

    public float Timedown;
    private bool gameOver = false;
    private bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SaveGame.LoadCoins();
        Slider.maxValue = 5;
        Slider.value = 5;
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
        CoinsText.text = "Coins:" + SaveGame.coinsGame;
    }
    #region state game
   
    public void ShowGameOver()
    {
        GameoverPanel.SetActive(true);
        //Player1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
        Time.timeScale = 1;
        gameOver = false;
        GameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
    }
    public void NextButton()
    {
        Slider.maxValue += 5;
        Slider.value = Slider.maxValue;
        VictoriPanel.SetActive(false);
        Time.timeScale = 1;
    }
    #endregion
}