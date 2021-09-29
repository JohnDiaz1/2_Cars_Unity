using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CloudOnce;

public class PlayServices : MonoBehaviour
{
    private void Start()
    {

        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        Cloud.Initialize(false, true);
    }

    public void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
        Cloud.Storage.Load();
    }

    public static void AddScoreToLeaderBoard()
    {
        Leaderboards.Top_players.SubmitScore(PlayerPrefs.GetInt("record"));
    }

    public static int UpdateUI()
    {
        Cloud.Storage.Load();

        int score = CloudVariables.HighScore;

        return score;
    }

    public static void ads()
    {
        Cloud.Storage.Load();
        PlayerPrefs.SetInt("ads", CloudVariables.Ads);
    }

    public static void SaveCloudScore()
    {
        Cloud.Storage.Load();
        CloudVariables.HighScore = PlayerPrefs.GetInt("record");
        Cloud.Storage.Save();
    }

    public static void SaveAds()
    {
        Cloud.Storage.Load();
        CloudVariables.Ads = PlayerPrefs.GetInt("ads");
        Cloud.Storage.Save();
    }

}
