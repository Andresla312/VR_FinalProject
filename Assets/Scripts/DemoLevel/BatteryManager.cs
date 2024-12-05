using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour
{
    [Header("Battery Sprites")] //Sprites para cada estado de la batería
    public Sprite batteryFull;
    public Sprite batteryThreeQuarters;
    public Sprite batteryHalf;
    public Sprite batteryLow;
    public Sprite noBattery;

    [Header("Battery Settings")]
    public Image batteryIcon; // La referencia al objeto UI Image
    public float batteryDuration = 60f; // Duración total de la batería en segundos

    [Header("Control Settings")]
    public bool isPaused = false; // Indica si la descarga está pausada

    private float batteryTimer;
    private float batteryInterval;

    void Start()
    {
        // Calcular el intervalo de tiempo para cada nivel de batería
        batteryTimer = batteryDuration;
        batteryInterval = batteryDuration / 4f; // 4 niveles entre Full y NoBattery

        UpdateBatteryIcon(); // Inicializar el sprite correcto
    }

    void Update()
    {
        // Si la descarga no está pausada, reducir el tiempo
        if (!isPaused && batteryTimer > 0)
        {
            batteryTimer -= Time.deltaTime;
            UpdateBatteryIcon();
        }
        else if (batteryTimer <= 0)
        {
            // Asegurarse de que la batería esté completamente descargada
            batteryTimer = 0;
            batteryIcon.sprite = noBattery;
        }
    }

    void UpdateBatteryIcon()
    {
        // Cambiar el sprite basado en el tiempo restante
        if (batteryTimer > 3 * batteryInterval)
        {
            batteryIcon.sprite = batteryFull;
        }
        else if (batteryTimer > 2 * batteryInterval)
        {
            batteryIcon.sprite = batteryThreeQuarters;
        }
        else if (batteryTimer > batteryInterval)
        {
            batteryIcon.sprite = batteryHalf;
        }
        else if (batteryTimer > 0)
        {
            batteryIcon.sprite = batteryLow;
        }
        else
        {
            batteryIcon.sprite = noBattery;
        }
    }

    // Método público para pausar la descarga
    public void PauseBatteryDrain()
    {
        isPaused = true;
    }

    // Método público para reanudar la descarga
    public void ResumeBatteryDrain()
    {
        isPaused = false;
    }
}
