using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundCategory
    {
        public string name;           // Nombre de la categor�a
        public AudioClip[] sounds;    // Lista de sonidos en esta categor�a
        public Color color;           // Color asociado con esta categor�a
    }

    public SoundCategory[] soundCategories;   // Array de categor�as de sonidos
    public GameObject spherePrefab;           // Prefab de la esfera visual
    public GameObject wavePrefab;             // Prefab de la onda visual

    public void PlaySoundAtWithColor(Vector3 position, string soundColor)
    {
        // Convierte el nombre del color a min�sculas para mayor flexibilidad
        string colorName = soundColor.ToLower();

        // Buscar la categor�a de sonido correspondiente al color
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
            // Selecciona un sonido aleatorio de esa categor�a
            int soundIndex = Random.Range(0, category.sounds.Length);
            AudioClip clip = category.sounds[soundIndex];

            // Reproduce el sonido en la posici�n indicada
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
        switch (colorName.ToLower())  // Convertimos la cadena a min�sculas para mayor flexibilidad
        {
            case "yellow":
                return Color.yellow;
            case "red":
                return Color.red;
            case "green":
                return Color.green;
            default:
                Debug.LogError("Color no soportado: " + colorName);  // A�adimos un log si el color no es soportado
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
