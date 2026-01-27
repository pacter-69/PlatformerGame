using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public void ChangeToLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
    void OnChangeGameplay()
    {
        ChangeToLevel();
    }
    void OnClose()
    {
        Application.Quit();
    }

}
