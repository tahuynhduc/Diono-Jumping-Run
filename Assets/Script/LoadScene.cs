using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //click chuyen scene MainMenu
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //click chuyen scene select mode
    public void PlayButton()
    {
        SceneManager.LoadScene("SelectMode");
    }
    #region scene SelectMode
    //click chuyen scene ScelectMap
    public void EndlessMode()
    {
        SceneManager.LoadScene("SelectMapEndless");
    }
    //click chuyen scene ScelectLevel
    public void NormalMode()
    {
        SceneManager.LoadScene("SelectMapNormal");
    }
    //click chuyen scene MainMenu
    public void backScelectMode()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region Scene SelectMap
    //click chuyen scene Gameplay
    public void SelectMapEndless()
    {
        SceneManager.LoadScene("GameplayEndless");
    }
    public void SelectMapNormal()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    //click chuyen scene SelectMode
    public void backSelectMap()
    {
        SceneManager.LoadScene("SelectMode");
    }
    #endregion

    #region Level Normal
    public void backSelectLevel()
    {
        SceneManager.LoadScene("SelectMapNormal");
    }
    public void chooseLevel()
    {
        SceneManager.LoadScene("GameplayNormal");
    }
    #endregion
}
