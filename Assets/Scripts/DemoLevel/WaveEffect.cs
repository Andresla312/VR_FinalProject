using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEffect : MonoBehaviour
{
    public float expansionSpeed = 2f;
    public float fadeSpeed = 1f;

    private Material waveMaterial;

    private void Start()
    {
        waveMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Expandir la onda
        transform.localScale += Vector3.one * expansionSpeed * Time.deltaTime;

        // Reducir la opacidad
        Color color = waveMaterial.color;
        color.a -= fadeSpeed * Time.deltaTime;
        waveMaterial.color = color;

        // Destruir cuando la opacidad sea cero
        if (color.a <= 0f)
        {
            Destroy(gameObject);
        }
    }
}