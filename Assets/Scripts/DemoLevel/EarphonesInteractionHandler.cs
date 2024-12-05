using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarphonesInteractionHandler : MonoBehaviour
{
    [SerializeField]
    private RayInteractable rayInteractable; // Referencia al interactable

    public static bool isUsingEarphones; // Indica si los earphones están en uso

    private void Awake()
    {
        if (rayInteractable == null)
        {
            Debug.LogError("RayInteractable no está asignado en " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        rayInteractable.WhenPointerEventRaised += HandlePointerEvent;
    }

    private void OnDisable()
    {
        rayInteractable.WhenPointerEventRaised -= HandlePointerEvent;
    }

    private void HandlePointerEvent(PointerEvent pointerEvent)
    {
        if (pointerEvent.Type == PointerEventType.Select)
        {
            isUsingEarphones = true; // Activar los earphones
        }
        else if (pointerEvent.Type == PointerEventType.Unselect)
        {
            isUsingEarphones = false; // Desactivar los earphones
        }
    }
}
