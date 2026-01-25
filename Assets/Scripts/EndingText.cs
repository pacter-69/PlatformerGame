using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{
    void Start()
    {
        Text text = GetComponent<Text>();

        string result = GameResult.PlayerWon ? "¡HAS GANADO!" : "HAS PERDIDO...";
        text.text = result + "\n\nPUNTUACIÓN: " + GameResult.FinalScore;
    }
}
