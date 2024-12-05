using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPointTrigger : MonoBehaviour
{
    public float detectionRange = 5f; // Rango de detección
    public GameObject player; // Referencia al jugador
    public string soundColor; // Color del sonido (Yellow, Red, etc.)
    private bool isInRange = false;

    public float damageRate = 10f; // Daño por segundo para amarillo
    public float damageRateRed = 20f; // Daño por segundo para rojo

    public SoundManager soundManager; // Referencia al SoundManager

    private void Update()
    {
        // Comprobación de distancia
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= detectionRange)
        {
            if (!isInRange)
            {
                isInRange = true;
                // Llamar a la función del SoundManager usando el color y sonido correspondiente
                soundManager.PlaySoundAtWithColor(transform.position, soundColor);

                // Iniciar el daño si el sonido es amarillo o rojo
                StartCoroutine(ApplyDamage());
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
            if (!HeadphoneInteractionHandler.isUsingHeadphones && !EarphonesInteractionHandler.isUsingEarphones)
            {
                // Sin protección de audífonos o earphones
                if (soundColor == "Yellow")
                {
                    PlayerHealth.instance.TakeDamage(damageRate * Time.deltaTime);
                }
                else if (soundColor == "Red")
                {
                    PlayerHealth.instance.TakeDamage(damageRateRed * Time.deltaTime);
                }
            }
            else if (EarphonesInteractionHandler.isUsingEarphones)
            {
                // Protección parcial con earphones
                if (soundColor == "Yellow")
                {
                    // Sin daño por sonidos amarillos
                    PlayerHealth.instance.TakeDamage(0);
                }
                else if (soundColor == "Red")
                {
                    // Mitigación de daño de sonidos rojos
                    PlayerHealth.instance.TakeDamage((damageRateRed / 2) * Time.deltaTime);
                }
            }
            yield return null;
        }
    }
}
