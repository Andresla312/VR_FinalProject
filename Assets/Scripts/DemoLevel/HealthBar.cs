using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; //Slider de la barra de vida del jugador

    public void SetMaxHealth(float maxHealth) //Función para establecer la vida máxima del jugador
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(float currentHealth) //Actualizar la vida actual del jugador
    {
        healthSlider.value = currentHealth;
    }
}
