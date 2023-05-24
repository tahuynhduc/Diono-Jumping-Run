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
    public Text scoreText;
    public Text bestScoreText;

    private int score;
    private long bestScore;
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
        GameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
        zeroScore();
        Time.timeScale = 1;
    }
    public void continueButton()
    {
        Time.timeScale = 1;
        gameOver = false;
        GameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        pause = false;
    }
    #endregion
}
