using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;  // Velocidad del movimiento
    [SerializeField] private float rotationSpeed = 5f;  // Velocidad de rotaci�n
    [SerializeField] private Transform[] waypoints;  // Array de waypoints
    private int currentWaypointIndex = 0;  // �ndice del waypoint actual
    private bool isLevelFinished = false;  // Variable para saber si el nivel termin�

    private void Update()
    {
        // Si el nivel termin�, se detiene el movimiento
        if (isLevelFinished || waypoints.Length == 0) return;

        // Movimiento hacia el waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Rotaci�n para mirar hacia el waypoint
        Vector3 directionToTarget = (targetWaypoint.position - transform.position).normalized;
        if (directionToTarget != Vector3.zero) // Evitar errores cuando est�n en el mismo punto
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Verificar si lleg� al waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Si es el �ltimo waypoint, el jugadr se detiene
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                isLevelFinished = true;
                OnLevelFinished();  // Llama al m�todo para manejar el final del nivel
            }
            else
            {
                // Cambiar al siguiente waypoint
                currentWaypointIndex++;
            }
        }
    }

    private void OnLevelFinished()
    {
        SceneManager.LoadScene("Win");
    }
}
