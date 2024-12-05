using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainMenu")
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (currentScene == "GameOver")
        {
            SceneManager.LoadScene("DemoLevel");
        }
        else if (currentScene == "Win")
        {
            SceneManager.LoadScene("DemoLevel");
        }
    }

    public void QuitGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainMenu")
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
        else if (currentScene == "GameOver")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (currentScene == "Win")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            PlayGame(); 
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            QuitGame();
        }
    }
}