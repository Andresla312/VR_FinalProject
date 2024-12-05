using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource mainBackgroundSource; // AudioSource para la m�sica principal
    [SerializeField] private AudioSource additionalSoundSource; // AudioSource para el sonido adicional
    [SerializeField] private AudioClip mainBackgroundMusic; // Clip de la m�sica principal
    [SerializeField] private AudioClip additionalBackgroundSound; // Clip del sonido adicional

    private static BackgroundMusicManager instance;

    void Awake()
    {
        // Evitar duplicados del BackgroundMusicManager
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Iniciar la m�sica solo en la escena del men� principal
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMainBackgroundMusic();
        }
    }

    private void PlayMainBackgroundMusic()
    {
        if (mainBackgroundSource != null && mainBackgroundMusic != null)
        {
            mainBackgroundSource.clip = mainBackgroundMusic;
            mainBackgroundSource.loop = true; // Aseg�rate de que la m�sica sea continua
            mainBackgroundSource.Play();
        }
    }

    private void PauseMainBackgroundMusic()
    {
        if (mainBackgroundSource != null && mainBackgroundSource.isPlaying)
        {
            mainBackgroundSource.Pause();
        }
    }

    private void ResumeMainBackgroundMusic()
    {
        if (mainBackgroundSource != null && !mainBackgroundSource.isPlaying)
        {
            mainBackgroundSource.Play();
        }
    }

    private void PlayAdditionalSound()
    {
        if (additionalSoundSource != null && additionalBackgroundSound != null)
        {
            additionalSoundSource.clip = additionalBackgroundSound;
            additionalSoundSource.loop = true; // Ajusta seg�n prefieras
            additionalSoundSource.Play();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Tutorial")
        {
            PauseMainBackgroundMusic(); // Pausar m�sica en la escena del videoclip
        }
        else if (sceneName == "DemoLevel")
        {
            ResumeMainBackgroundMusic(); // Reanudar m�sica principal
            PlayAdditionalSound(); // Reproducir el sonido adicional
        }
        else if (sceneName == "MainMenu")
        {
            if (!mainBackgroundSource.isPlaying)
            {
                PlayMainBackgroundMusic();
            }
        }
    }
}