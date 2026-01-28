using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Kill"))
        {
            GameResult.PlayerWon = false;
            GameResult.FinalScore = FindFirstObjectByType<ScoreSystem>().Score;
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kill"))
        {
            GameResult.PlayerWon = false;
            GameResult.FinalScore = FindFirstObjectByType<ScoreSystem>().Score;
            SceneManager.LoadScene("Ending");
        }
    }
}