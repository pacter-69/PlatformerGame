using TMPro;
using UnityEngine;

public class EndingText : MonoBehaviour
{
    void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();

        string result = GameResult.PlayerWon ? "YOU WIN" : "YOU LOSE";
        text.text = result + "\n\nSCORE: " + GameResult.FinalScore;
    }
}
