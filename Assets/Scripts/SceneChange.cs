using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
