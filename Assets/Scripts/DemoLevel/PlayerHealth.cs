using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; //Instancia del PlayerHealth
    public float maxHealth = 100f; // Salud máxima
    public float currentHealth; // Salud actual
    public Slider healthSlider; // Slider de la barra de vida

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentHealth = maxHealth; //Establecemos la vida actual como la vida máxima (100hp)
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    // Función para recibir daño
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();
    }

    // Actualiza la barra de vida
    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
