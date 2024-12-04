using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPointTrigger : MonoBehaviour
{
    public SoundManager soundManager; // Referencia al SoundManager
    [SerializeField] private Transform player;
    [SerializeField] private float activationDistance = 1.0f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= activationDistance)
        {
            Debug.Log("El jugador activó el waypoint manualmente.");
            soundManager.PlayRandomSoundAt(transform.position);
            Destroy(this); // Evita múltiples activaciones
        }
    }
}
