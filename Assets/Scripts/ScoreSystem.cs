using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public int Score = 0;
    public int MaxScore = 3200;
    //public delegate void OnScoredDelegate(int score);
    //public static event OnScoredDelegate OnScored;

    public static Action<int> OnScoreUpdated;
    private void OnEnable()
    {
        Coin.OnCoinCollected += UpdateScore;
    }
    private void OnDisable()
    {
        Coin.OnCoinCollected -= UpdateScore;
    }
    private void UpdateScore(int value)
    {
        Score += value;
        OnScoreUpdated?.Invoke(Score);
    }

    public void IsMaxScoreReached(int score)
    {
        if(score == MaxScore)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
