using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundCategory
    {
        public string name;           // Nombre de la categoría
        public AudioClip[] sounds;    // Lista de sonidos en esta categoría
        public Color color;           // Color asociado con esta categoría
    }

    public SoundCategory[] soundCategories;   // Array de categorías de sonidos
    public GameObject spherePrefab;           // Prefab de la esfera visual
    public GameObject wavePrefab;             // Prefab de la onda visual

    public void PlaySoundAtWithColor(Vector3 position, string soundColor)
    {
        // Convierte el nombre del color a minúsculas para mayor flexibilidad
        string colorName = soundColor.ToLower();

        // Buscar la categoría de sonido correspondiente al color
        SoundCategory category = null;
        foreach (var cat in soundCategories)
        {
            if (cat.name.ToLower() == colorName)
            {
                category = cat;
                break;
            }
        }

        if (category != null)
        {
            // Selecciona un sonido aleatorio de esa categoría
            int soundIndex = Random.Range(0, category.sounds.Length);
            AudioClip clip = category.sounds[soundIndex];

            // Reproduce el sonido en la posición indicada
            AudioSource.PlayClipAtPoint(clip, position);

            // Genera la esfera y la onda visual
            GenerateSphereWithWave(position, category.color);
        }
        else
        {
            Debug.LogError("No sound category found for the specified color: " + soundColor);
        }
    }

    private Color GetColorFromString(string colorName)
    {
        switch (colorName.ToLower())  // Convertimos la cadena a minúsculas para mayor flexibilidad
        {
            case "yellow":
                return Color.yellow;
            case "red":
                return Color.red;
            case "green":
                return Color.green;
            default:
                Debug.LogError("Color no soportado: " + colorName);  // Añadimos un log si el color no es soportado
                return Color.white; // Default color si no se encuentra el color
        }
    }

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
