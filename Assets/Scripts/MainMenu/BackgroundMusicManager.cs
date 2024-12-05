using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusicSource; // Referencia al AudioSource de la m�sica de fondo
    [SerializeField] private AudioClip mainBackgroundMusic; // Canci�n de fondo principal
    [SerializeField] private AudioClip additionalBackgroundSound; // Sonido adicional para la tercera escena

    private static BackgroundMusicManager instance;

    void Awake()
    {
        // Evitar duplicados del BackgroundMusicManager
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
            PlayMusic(mainBackgroundMusic);
        }
    }

    // M�todo para reproducir m�sica desde el inicio
    private void PlayMusic(AudioClip clip)
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop(); // Detener cualquier m�sica actual
            backgroundMusicSource.clip = clip; // Asignar la nueva canci�n
            backgroundMusicSource.Play(); // Reproducir desde el inicio
        }
    }

    // Este m�todo se llama al cargar una nueva escena
    void OnLevelWasLoaded(int level)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Tutorial")
        {
            // Detener la m�sica durante la escena del videoclip
            backgroundMusicSource.Stop();
        }
        else if (currentSceneName == "DemoLevel")
        {
            // Reproducir la m�sica principal desde el inicio en la tercera escena
            PlayMusic(mainBackgroundMusic);

            // Reproducir el sonido adicional (si es necesario)
            if (additionalBackgroundSound != null)
            {
                backgroundMusicSource.clip = additionalBackgroundSound;
                backgroundMusicSource.Play();
            }
        }
        else if (currentSceneName == "MainMenu")
        {
            // Asegurar que la m�sica del men� principal se reproduce
            PlayMusic(mainBackgroundMusic);
        }
    }
}
