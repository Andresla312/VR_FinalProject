using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundCategory
    {
        public string name;           // Nombre de la categor�a (opcional, para organizaci�n)
        public AudioClip[] sounds;    // Lista de sonidos en esta categor�a
        public Color color;           // Color asociado con esta categor�a
    }

    public SoundCategory[] soundCategories;   // Array de categor�as de sonidos
    public GameObject spherePrefab;           // Prefab de la esfera visual
    public GameObject wavePrefab;             // Prefab de la onda visual

    /// <summary>
    /// Reproduce un sonido aleatorio de cualquier categor�a en la posici�n especificada
    /// y genera la esfera con la onda visual.
    /// </summary>
    /// <param name="position">Posici�n en la que se reproducir� el sonido.</param>
    public void PlayRandomSoundAt(Vector3 position)
    {
        // Selecciona una categor�a aleatoria
        int categoryIndex = Random.Range(0, soundCategories.Length);
        SoundCategory category = soundCategories[categoryIndex];

        // Selecciona un sonido aleatorio de esa categor�a
        int soundIndex = Random.Range(0, category.sounds.Length);
        AudioClip clip = category.sounds[soundIndex];

        // Reproduce el sonido en la posici�n indicada
        AudioSource.PlayClipAtPoint(clip, position);

        // Genera la esfera y la onda visual
        GenerateSphereWithWave(position, category.color);
    }

    /// <summary>
    /// Genera una esfera y una onda visual en la posici�n especificada.
    /// </summary>
    /// <param name="position">Posici�n donde se generar�n los efectos visuales.</param>
    /// <param name="color">Color asociado a la categor�a del sonido.</param>
    private void GenerateSphereWithWave(Vector3 position, Color color)
    {
        // Crear la esfera
        if (spherePrefab != null)
        {
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
            sphere.GetComponent<Renderer>().material.color = color;

            // Destruir la esfera despu�s de un tiempo
            Destroy(sphere, 2f);
        }

        // Crear la onda
        if (wavePrefab != null)
        {
            GameObject wave = Instantiate(wavePrefab, position, Quaternion.identity);
            wave.GetComponent<Renderer>().material.color = color;

            // Destruir la onda despu�s de un tiempo
            Destroy(wave, 2f);
        }
    }
}
