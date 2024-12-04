using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSphere : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject wavePrefab; // Prefab de la onda visual

    public void Initialize(AudioClip clip, Color waveColor)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        // Crear la onda visual
        GameObject wave = Instantiate(wavePrefab, transform.position, Quaternion.identity);
        wave.GetComponent<Renderer>().material.color = waveColor;

        // Destruir la onda después de un tiempo
        Destroy(wave, 3f);
    }
}
