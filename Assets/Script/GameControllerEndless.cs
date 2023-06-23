
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameControllerEndless : GameController
{
    public int score;
    public long bestScore;
    private void Awake()
    {
        LoadScores();
    }

    private void LoadScores()
    {
        bestScore = DatabaseManager.LoadData<long>(DatabaseManager.DatabaseKey.BestScore,bestScore.ToString());
        Social.LoadScores(GPGSIds.leaderboard_testleaderboard, (score) =>
        {
            foreach (IScore test in score)
            {
                if (test.userID == Social.localUser.id)
                {
                    bestScore = test.value;
                }
            }
        });
    }

    public void ReportScore()
    {
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.BestScore,bestScore);
        Social.ReportScore(bestScore, GPGSIds.leaderboard_testleaderboard, (reportScore) =>
            {

            });
    }
}
