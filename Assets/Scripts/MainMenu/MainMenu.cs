using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DemoLevel");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) // Botón A
        {
            PlayGame();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two)) // Botón B
        {
            QuitGame();
        }
    }
}
