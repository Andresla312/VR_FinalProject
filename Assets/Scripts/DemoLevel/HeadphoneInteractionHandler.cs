using UnityEngine;
using Oculus.Interaction;

public class HeadphoneInteractionHandler : MonoBehaviour
{
    [SerializeField]
    private RayInteractable rayInteractable; // Referencia al interactable

    [SerializeField]
    private BatteryManager batteryManager; // Referencia al BatteryManager

    private void Awake()
    {
        if (rayInteractable == null)
        {
            Debug.LogError("RayInteractable no está asignado en " + gameObject.name);
        }

        if (batteryManager == null)
        {
            Debug.LogError("BatteryManager no está asignado en " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        // Suscribirse a los eventos
        rayInteractable.WhenPointerEventRaised += HandlePointerEvent;
    }

    private void OnDisable()
    {
        // Desuscribirse de los eventos
        rayInteractable.WhenPointerEventRaised -= HandlePointerEvent;
    }

    private void HandlePointerEvent(PointerEvent pointerEvent)
    {
        if (pointerEvent.Type == PointerEventType.Select)
        {
            // Activar la funcionalidad al agarrar
            batteryManager.isPaused = false;
        }
        else if (pointerEvent.Type == PointerEventType.Unselect)
        {
            // Desactivar la funcionalidad al soltar
            batteryManager.isPaused = true;
        }
    }
}
