using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UimanagerNormal : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject GameoverPanel;

    private bool gameOver = false;
    private bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            pauseButton.SetActive(false);
        }
    }
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
        Time.timeScale = 1;
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
}
