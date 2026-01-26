using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        Debug.Log("Salir del juego");
        Application.Quit();
    }

}
