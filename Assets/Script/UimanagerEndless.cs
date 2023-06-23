using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEngine.GUI;


public class UimanagerEndless : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject Removeads;
    [SerializeField] Text scoreText;
    [SerializeField] Text bestScoreText;
    GameControllerEndless gameControllerEndless;

    private void Start()
    {
        gameControllerEndless = FindAnyObjectByType<GameControllerEndless>();
        ShowBestScore();
    }
    #region  score
    public void ShowScore()
    {
        scoreText.text = "Score:" + gameControllerEndless.score;
    }
    #endregion

    #region BestScore
    public void ShowBestScore()
    {
        bestScoreText.text = "Best:" + gameControllerEndless.bestScore;
        if (gameControllerEndless.score > gameControllerEndless.bestScore)
        {
            gameControllerEndless.bestScore = gameControllerEndless.score;
            bestScoreText.text = "Best:" + gameControllerEndless.bestScore.ToString();
            gameControllerEndless.ReportScore();
        }
    }
    #endregion
    #region state gameplay endless
    public void ShowGameOver()
    {
        gameControllerEndless.StateGame(0);
        GameOverPanel.SetActive(true);
        Removeads.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void ShowPauseButton()
    {
        gameControllerEndless.StateGame(0);
        pausePanel.SetActive(true);
        Removeads.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void replayButton()
    {
        Removeads.SetActive(false);
        GameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        SceneManager.LoadScene("GameplayEndless");
    }
    public void continueButton()
    {
        gameControllerEndless.StateGame(1);
        Removeads.SetActive(false);
        GameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
    #endregion
}
