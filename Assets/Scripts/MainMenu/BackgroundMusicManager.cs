using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusicSource; // Referencia al AudioSource de la música de fondo
    [SerializeField] private AudioClip additionalBackgroundSound; // Nuevo sonido adicional que se reproducirá en la tercera escena

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
        // Iniciar la música solo si estamos en la escena del menú principal
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayBackgroundMusic();
        }
    }

    // Método para reproducir música de fondo en la escena del menú
    private void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
            isMusicPlaying = true;
        }
    }

    // Método para pausar la música
    private void PauseBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Pause();
            isMusicPlaying = false;
        }
    }

    // Método para reanudar la música
    private void ResumeBackgroundMusic()
    {
        if (backgroundMusicSource != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.UnPause();
            isMusicPlaying = true;
        }
    }

    // Este método se llamará cuando se cambie de escena
    void OnLevelWasLoaded(int level)
    {
        // Detener música en la escena del videoclip
        if (SceneManager.GetActiveScene().name == "VideoclipScene")
        {
            PauseBackgroundMusic();
        }
        // Reanudar la música en la tercera escena
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
        // Asegurarnos de que la música se reproduzca en la escena principal
        else if (SceneManager.GetActiveScene().name == "MainMenu" && !isMusicPlaying)
        {
            PlayBackgroundMusic();
        }
    }

    // Para manejar los cambios de escena cuando el jugador le da al botón Play
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("DemoLevel");
    }
}
