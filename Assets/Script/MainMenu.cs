using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject QuitPanel;
    public void QuitButton()
    {
        QuitPanel.SetActive(true);
        DatabaseManager.CoinsGame(0);
    }
    public void NoQuitGameButton()
    {
        QuitPanel.SetActive(false);
        DatabaseManager.CoinsGame(0);
    }
}
