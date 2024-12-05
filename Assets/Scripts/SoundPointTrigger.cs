using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPointTrigger : MonoBehaviour
{
    public float detectionRange = 5f; // Rango de detección
    public GameObject player; // Referencia al jugador
    public string soundColor; // Puede ser "Yellow" o "Red"
    private bool isInRange = false;

    public float damageRate = 10f; // Daño por segundo para amarillo
    public float damageRateRed = 20f; // Daño por segundo para rojo

    public GameObject soundSpherePrefab; // Prefab de la SoundSphere
    public Transform soundSphereSpawnPoint; // Punto de aparición de la esfera

    private void Update()
    {
        // Comprobación de distancia
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= detectionRange)
        {
            if (!isInRange)
            {
                isInRange = true;
                // Iniciar el daño si el sonido es amarillo o rojo
                StartCoroutine(ApplyDamage());
                SpawnSoundSphere();  // Llamar a la función para generar la esfera
            }
        }
        else
        {
            if (isInRange)
            {
                isInRange = false;
                // Detener el daño si el jugador sale del rango
                StopCoroutine(ApplyDamage());
            }
        }
    }

    private IEnumerator ApplyDamage()
    {
        while (isInRange)
        {
            // Aquí compruebas el color del sonido
            if (soundColor == "Yellow")
            {
                // Resta 10 hp por segundo si el sonido es amarillo
                PlayerHealth.instance.TakeDamage(damageRate * Time.deltaTime);
            }
            else if (soundColor == "Red")
            {
                // Resta 20 hp por segundo si el sonido es rojo
                PlayerHealth.instance.TakeDamage(damageRateRed * Time.deltaTime);
            }
            yield return null;
        }
    }

    // Función para generar la esfera de sonido
    private void SpawnSoundSphere()
    {
        if (soundSpherePrefab != null && soundSphereSpawnPoint != null)
        {
            GameObject sphere = Instantiate(soundSpherePrefab, soundSphereSpawnPoint.position, Quaternion.identity);

            // Aquí controlamos el color según el tipo de sonido
            if (soundColor == "Yellow")
            {
                sphere.GetComponent<Renderer>().material.color = Color.yellow; // Cambiar a color amarillo
            }
            else if (soundColor == "Red")
            {
                sphere.GetComponent<Renderer>().material.color = Color.red; // Cambiar a color rojo
            }
        }
    }

}
