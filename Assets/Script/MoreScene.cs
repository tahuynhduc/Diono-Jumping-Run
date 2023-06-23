using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreScene : MonoBehaviour
{
    [SerializeField] GameObject appInfo;
    public void ShowAppInfo()
    {
        appInfo.SetActive(true);
    }
    public void hidenAppInfo()
    {
        appInfo.SetActive(false);
    }
    public void ShowRate()
    {
        Application.OpenURL("https://docs.unity3d.com/ScriptReference/Application.OpenURL.html");
    }
    public void ShowMoreGame()
    {
        Application.OpenURL("https://docs.unity3d.com/ScriptReference/Application.OpenURL.html");
    }
}
