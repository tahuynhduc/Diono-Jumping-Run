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

    public float checkLevel;
    public float Timedown;
    private bool gameOver = false;
    private bool pause = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        SaveGame.LoadCoins();
        checkLevel = PlayerPrefs.GetFloat("checkLevel", checkLevel);
        Debug.Log(checkLevel);
        Slider.maxValue = checkLevel;
        Slider.value = checkLevel;

    }
    void Start()
    {
        Debug.Log(Slider.value);
        Debug.Log(Slider.maxValue);
        PlayerPrefs.SetFloat("checkLevel",checkLevel);
        PlayerPrefs.Save();
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
        SceneManager.LoadScene("GameplayNormal");
        checkLevel +=20;
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("checkLevel", checkLevel);
        PlayerPrefs.Save();
    }
    #endregion
}