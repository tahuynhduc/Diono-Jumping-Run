using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEngine.GUI;


public class Uimanager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject GameOverPanel;
    public GameObject Removeads;
    public Text scoreText;
    public Text bestScoreText;

    private int score;
    long bestScore;
    private bool gameOver = false;
    private bool pause = false;
   

    private void Start()
    {
        Social.LoadScores(GPGSIds.leaderboard_testleaderboard, (score) =>
        {
            foreach (IScore test in score)
            {
                if (test.userID == Social.localUser.id)
                {
                    bestScore = test.value;
                    bestScoreText.text = "Best:" + bestScore;
                }
            }
        });
    }
    void Update()
    {
        
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
    public void ShowScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    #endregion

    #region BestScore
    public void ShowBestScore()
    {
        if (score>bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best:" + bestScore.ToString();
            Social.ReportScore(bestScore, GPGSIds.leaderboard_testleaderboard, (reportScore) =>
            {
            });
        }
    }
    #endregion

    #region state gameplay endless
    public void ShowGameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        Removeads.SetActive(true);
        //Player1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameOver = true;
    }
    public void ShowPauseButton()
    {
        pausePanel.SetActive(true);
        Removeads.SetActive(true);
        pause = true;
    }
    public void replayButton()
    {
        SceneManager.LoadScene("GameplayEndless");
        gameOver = false;
        Removeads.SetActive(false);
        GameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }
    public void continueButton()
    {
        Time.timeScale = 1;
        gameOver = false;
        Removeads.SetActive(false);
        GameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
    }
    #endregion
}
