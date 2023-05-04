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

    int checkMap;
    float unlockState;
    float unlockStateDesert;
    float unlockStateGraveyard;
    float unlockStateSnow;
    public float valueSlider;
    public float Timedown;
    private bool gameOver = false;
    private bool pause = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        SaveGame.LoadCoins();
        unlockState = PlayerPrefs.GetFloat("unlockState", unlockState);
        unlockStateDesert = PlayerPrefs.GetFloat("unlockStateDesert", unlockStateDesert);
        unlockStateGraveyard = PlayerPrefs.GetFloat("unlockStateGraveyard", unlockStateGraveyard);
        unlockStateSnow = PlayerPrefs.GetFloat("unlockStateSnow", unlockStateSnow);
        valueSlider = PlayerPrefs.GetFloat("valueSlider", valueSlider);
        checkMap = PlayerPrefs.GetInt("checkmap", checkMap);
        Slider.maxValue = valueSlider;
        Slider.value = valueSlider;
        Slider.minValue = 0;
        Debug.Log(valueSlider);

    }
    void Start()
    {
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
        valueSlider += 20;
        PlayerPrefs.SetFloat("valueSlider", valueSlider);
        PlayerPrefs.Save();
        if (checkMap == 1 && unlockState < valueSlider)
        {
            unlockState = valueSlider;
            PlayerPrefs.SetFloat("unlockState", unlockState);
            PlayerPrefs.Save();
        }
        if(checkMap == 2 && unlockStateDesert < valueSlider)
        {
            unlockStateDesert = valueSlider;
            PlayerPrefs.SetFloat("unlockStateDesert", unlockStateDesert);
            PlayerPrefs.Save();
        }
        if (checkMap == 3 && unlockStateGraveyard < valueSlider)
        {
            unlockStateGraveyard = valueSlider;
            PlayerPrefs.SetFloat("unlockStateGraveyard", unlockStateGraveyard);
            PlayerPrefs.Save();
        }
        if (checkMap == 4 && unlockStateSnow < valueSlider)
        {
            unlockStateSnow = valueSlider;
            PlayerPrefs.SetFloat("unlockStateSnow", unlockStateSnow);
            PlayerPrefs.Save();
        }
    }
    #endregion
}