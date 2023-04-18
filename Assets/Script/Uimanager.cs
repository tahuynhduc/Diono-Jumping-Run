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
    SceneLoader test;

    private int score;
    private int bestScore;
    private bool gameOver = false;
    private bool pause = false;
    private void Start()
    {
        test = FindObjectOfType<SceneLoader>();
        LoadBestScore();
    }
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
    }
    void SaveBestScore()
    {
        bestScoreText.text = "Best: " + bestScore;
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();
    }
    void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        bestScoreText.text = "Best: " + bestScore;
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
