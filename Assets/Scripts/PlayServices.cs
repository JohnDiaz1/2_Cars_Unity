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
    }

    public static void AddScoreToLeaderBoard()
    {
        Leaderboards.Top_players.SubmitScore(PlayerPrefs.GetInt("record"));
    }

}
