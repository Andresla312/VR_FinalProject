using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusicSource; // Referencia al AudioSource de la m�sica de fondo
    [SerializeField] private AudioClip additionalBackgroundSound; // Nuevo sonido adicional que se reproducir� en la tercera escena

    private static BackgroundMusicManager instance;
    private bool isMusicPlaying = false;

    void Awake()
    {
        // Si ya existe un BackgroundMusicManager, destruir este objeto para evitar duplicados
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Mantener el objeto entre escenas
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Iniciar la m�sica solo si estamos en la escena del men� principal
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayBackgroundMusic();
        }
    }

    // M�todo para reproducir m�sica de fondo en la escena del men�
    private void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
            isMusicPlaying = true;
        }
    }

    // M�todo para pausar la m�sica
    private void PauseBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Pause();
            isMusicPlaying = false;
        }
    }

    // M�todo para reanudar la m�sica
    private void ResumeBackgroundMusic()
    {
        if (backgroundMusicSource != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.UnPause();
            isMusicPlaying = true;
        }
    }

    // Este m�todo se llamar� cuando se cambie de escena
    void OnLevelWasLoaded(int level)
    {
        // Detener m�sica en la escena del videoclip
        if (SceneManager.GetActiveScene().name == "VideoclipScene")
        {
            PauseBackgroundMusic();
        }
        // Reanudar la m�sica en la tercera escena
        else if (SceneManager.GetActiveScene().name == "ThirdScene")
        {
            if (!isMusicPlaying)
            {
                ResumeBackgroundMusic();
            }
            // Reproducir el sonido adicional en la tercera escena
            if (additionalBackgroundSound != null)
            {
                backgroundMusicSource.clip = additionalBackgroundSound;
                backgroundMusicSource.Play();
            }
        }
        // Asegurarnos de que la m�sica se reproduzca en la escena principal
        else if (SceneManager.GetActiveScene().name == "MainMenu" && !isMusicPlaying)
        {
            PlayBackgroundMusic();
        }
    }

    // Para manejar los cambios de escena cuando el jugador le da al bot�n Play
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("DemoLevel");
    }
}
