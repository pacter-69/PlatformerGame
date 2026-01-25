using UnityEngine;

public class CloseGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
