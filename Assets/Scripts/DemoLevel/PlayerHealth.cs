using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; //Instancia del PlayerHealth
    public float maxHealth = 100f; // Salud m�xima
    public float currentHealth; // Salud actual
    public Slider healthSlider; // Slider de la barra de vida

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentHealth = maxHealth; //Establecemos la vida actual como la vida m�xima (100hp)
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    // Funci�n para recibir da�o
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
