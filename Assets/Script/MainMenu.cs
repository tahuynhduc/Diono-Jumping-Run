using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject QuitPanel;
    public void QuitButton()
    {
        QuitPanel.SetActive(true);
        SaveGame.SaveCoins();
    }
    public void NoQuitGameButton()
    {
        QuitPanel.SetActive(false);
        SaveGame.SaveCoins();
    }
}
