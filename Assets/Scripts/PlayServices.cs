using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate(succes => { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PostScore(long score, string leaderBoard)
    {
        Social.ReportScore(score, leaderBoard, (success => { }));
    }

    public static void ShowLeaderboard(string leaderBoard)
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderBoard);
    }

    public static long GetPlayerScore(string leaderBoard)
    {
        long score = 0;
        PlayGamesPlatform.Instance.LoadScores(leaderBoard, LeaderboardStart.PlayerCentered, 1, LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime, (LeaderboardScoreData data) => { score = data.PlayerScore.value; });
        return score;
    }

    public static void UnlockAchievment(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void IncrementAchivment(string id, int steps)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, steps, success => { });
    }

    public static void ShowAchievments()
    {
        Social.ShowAchievementsUI();
    }
}
