using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusicSource; // Referencia al AudioSource de la música de fondo
    [SerializeField] private AudioClip mainBackgroundMusic; // Canción de fondo principal
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
        // Iniciar la música solo si estamos en la escena del menú principal
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMusic(mainBackgroundMusic);
        }
    }

    // Método para reproducir música desde el inicio
    private void PlayMusic(AudioClip clip)
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop(); // Detener cualquier música actual
            backgroundMusicSource.clip = clip; // Asignar la nueva canción
            backgroundMusicSource.Play(); // Reproducir desde el inicio
        }
    }

    // Este método se llama al cargar una nueva escena
    void OnLevelWasLoaded(int level)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Tutorial")
        {
            // Detener la música durante la escena del videoclip
            backgroundMusicSource.Stop();
        }
        else if (currentSceneName == "DemoLevel")
        {
            // Reproducir la música principal desde el inicio en la tercera escena
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
            // Asegurar que la música del menú principal se reproduce
            PlayMusic(mainBackgroundMusic);
        }
    }
}
