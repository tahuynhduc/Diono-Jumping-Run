using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Uimanager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject GameoverButton;
    public Text scoreText;
    public Text bestScoreText;

    private int score;
    private int bestScore;
    private bool gameOver = false;
    private bool pause = false;
    void Update()
    {
        ShowBestScore();
        if (pause)
        {
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            ShowBestScore();
            pauseButton.SetActive(false);
        }
    }
    #region  score
    public int scoreEndless()
    {
        return score = 0;
    }
    public void ShowScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    public void zeroScore()
    {
        scoreEndless();
        scoreText.text = "Score: " ;
    }
    #endregion

    #region BestScore
    public void ShowBestScore()
    {
        if (score>bestScore)
        {
            bestScore = score;
            SaveBestScore();
        }
        LoadBestScore();
    }
    void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();
    }
    void LoadBestScore()
    {
        bestScoreText.text = "Best: " + bestScore;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }
    #endregion

    #region state gameplay endless
    public void ShowGameOver()
    {
        GameoverButton.SetActive(true);
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
        SceneManager.LoadScene("GameplayEndless");
        Time.timeScale = 1;
        gameOver = false;
        GameoverButton.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
        zeroScore();
    }
    public void continueButton()
    {
        Time.timeScale = 1;
        gameOver = false;
        GameoverButton.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
    }


    #endregion

  
}
