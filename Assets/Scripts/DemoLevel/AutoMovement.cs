using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;  // Velocidad del movimiento
    [SerializeField] private float rotationSpeed = 5f;  // Velocidad de rotación
    [SerializeField] private Transform[] waypoints;  // Array de waypoints
    private int currentWaypointIndex = 0;  // Índice del waypoint actual
    private bool isLevelFinished = false;  // Variable para saber si el nivel terminó

    private void Update()
    {
        // Si el nivel terminó, se detiene el movimiento
        if (isLevelFinished || waypoints.Length == 0) return;

        // Movimiento hacia el waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Rotación para mirar hacia el waypoint
        Vector3 directionToTarget = (targetWaypoint.position - transform.position).normalized;
        if (directionToTarget != Vector3.zero) // Evitar errores cuando están en el mismo punto
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Verificar si llegó al waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Si es el último waypoint, el jugadr se detiene
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                isLevelFinished = true;
                OnLevelFinished();  // Llama al método para manejar el final del nivel
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
