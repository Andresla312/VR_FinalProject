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

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null && buttonClickClip != null)
        {
            buttonClickSound.PlayOneShot(buttonClickClip);
        }
    }
}