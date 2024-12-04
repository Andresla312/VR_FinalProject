using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundCategory
    {
        public string name;           // Nombre de la categoría (opcional, para organización)
        public AudioClip[] sounds;    // Lista de sonidos en esta categoría
        public Color color;           // Color asociado con esta categoría
    }

    public SoundCategory[] soundCategories;   // Array de categorías de sonidos
    public GameObject spherePrefab;           // Prefab de la esfera visual
    public GameObject wavePrefab;             // Prefab de la onda visual

    /// <summary>
    /// Reproduce un sonido aleatorio de cualquier categoría en la posición especificada
    /// y genera la esfera con la onda visual.
    /// </summary>
    /// <param name="position">Posición en la que se reproducirá el sonido.</param>
    public void PlayRandomSoundAt(Vector3 position)
    {
        // Selecciona una categoría aleatoria
        int categoryIndex = Random.Range(0, soundCategories.Length);
        SoundCategory category = soundCategories[categoryIndex];

        // Selecciona un sonido aleatorio de esa categoría
        int soundIndex = Random.Range(0, category.sounds.Length);
        AudioClip clip = category.sounds[soundIndex];

        // Reproduce el sonido en la posición indicada
        AudioSource.PlayClipAtPoint(clip, position);

        // Genera la esfera y la onda visual
        GenerateSphereWithWave(position, category.color);
    }

    /// <summary>
    /// Genera una esfera y una onda visual en la posición especificada.
    /// </summary>
    /// <param name="position">Posición donde se generarán los efectos visuales.</param>
    /// <param name="color">Color asociado a la categoría del sonido.</param>
    private void GenerateSphereWithWave(Vector3 position, Color color)
    {
        // Crear la esfera
        if (spherePrefab != null)
        {
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
            sphere.GetComponent<Renderer>().material.color = color;

            // Destruir la esfera después de un tiempo
            Destroy(sphere, 2f);
        }

        // Crear la onda
        if (wavePrefab != null)
        {
            GameObject wave = Instantiate(wavePrefab, position, Quaternion.identity);
            wave.GetComponent<Renderer>().material.color = color;

            // Destruir la onda después de un tiempo
            Destroy(wave, 2f);
        }
    }
}
