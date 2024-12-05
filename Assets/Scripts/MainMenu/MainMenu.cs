using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickSound;
    [SerializeField] private AudioClip buttonClickClip;

    public void PlayGame()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("DemoLevel");
    }

    public void QuitGame()
    {
        PlayButtonClickSound();
        Debug.Log("Quit Game");
        Application.Quit();
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null && buttonClickClip != null)
        {
            buttonClickSound.PlayOneShot(buttonClickClip);
        }
    }
}
