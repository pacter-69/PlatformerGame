using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public int Score = 0;
    public int MaxScore = 3200;

    public static event Action<int> OnScoreUpdated;

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
        IsMaxScoreReached(Score);
    }

    public void IsMaxScoreReached(int score)
    {
        if(score >= MaxScore)
        {
            GameResult.PlayerWon = true;
            GameResult.FinalScore = Score;
            SceneManager.LoadScene("Ending");
        }
    }
}