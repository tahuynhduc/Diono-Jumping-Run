using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject QuitPanel;
    SettingMusic setting;
    private void Update()
    {
        setting = FindAnyObjectByType<SettingMusic>();
    }
    public void QuitButton()
    {
        QuitPanel.SetActive(true);
    }
    public void NoQuitGameButton()
    {
        QuitPanel.SetActive(false);
    }
}
