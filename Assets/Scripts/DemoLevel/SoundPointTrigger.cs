using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPointTrigger : MonoBehaviour
{
    public float detectionRange = 5f; // Rango de detecci�n
    public GameObject player; // Referencia al jugador
    public string soundColor; // Color del sonido (Yellow, Red, etc.)
    private bool isInRange = false;

    public float damageRate = 10f; // Da�o por segundo para amarillo
    public float damageRateRed = 20f; // Da�o por segundo para rojo

    public SoundManager soundManager; // Referencia al SoundManager

    private void Update()
    {
        // Comprobaci�n de distancia
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= detectionRange)
        {
            if (!isInRange)
            {
                isInRange = true;
                // Llamar a la funci�n del SoundManager usando el color y sonido correspondiente
                soundManager.PlaySoundAtWithColor(transform.position, soundColor);

                // Iniciar el da�o si el sonido es amarillo o rojo
                StartCoroutine(ApplyDamage());
            }
        }
        else
        {
            if (isInRange)
            {
                isInRange = false;
                // Detener el da�o si el jugador sale del rango
                StopCoroutine(ApplyDamage());
            }
        }
    }

    private IEnumerator ApplyDamage()
    {
        while (isInRange)
        {
            // Aqu� comprobamos el color del sonido y aplicamos el da�o
            if (soundColor == "Green")
            {
                // Resta 10 hp por segundo si el sonido es amarillo
                PlayerHealth.instance.TakeDamage(0 * Time.deltaTime);
            }
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
}
