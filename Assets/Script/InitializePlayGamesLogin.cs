using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Mono.Cecil.Cil;
using System;

public class InitializePlayGamesLogin : MonoBehaviour
{
    private PlayGamesClientConfiguration config;
    private void Awake()
    {
        ConfigureGPGS();
        SigIntoGPGS(SignInInteractivity.CanPromptOnce,config);
    }

    internal void ConfigureGPGS()
    {
        config = new PlayGamesClientConfiguration.Builder().Build();
    }
    internal void SigIntoGPGS(SignInInteractivity interactivity,PlayGamesClientConfiguration configuration)
    {
        configuration = config;
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(interactivity,(code) =>
        {
            if (code == SignInStatus.Success) 
            {
                Debug.Log(code);
            }
            else
            {
                Debug.Log(code);
            }
        });
    }
    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
    public void ShowAchiverment()
    {
        Social.ShowAchievementsUI();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
