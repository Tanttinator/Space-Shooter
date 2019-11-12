using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Handles player movement
[RequireComponent(typeof(Ship))]
public class PlayerController : MonoBehaviour
{
    Ship ship;

    Interactable currentInteractable = null;
    List<Interactable> interactables = new List<Interactable>();

    public void AddInteractable(Interactable interactable)
    {
        interactables.Insert(0, interactable);
        SetInteractable(interactable);
    }

    public void RemoveInteractable(Interactable interactable)
    {
        interactables.Remove(interactable);
        if (interactables.Count > 0)
            SetInteractable(interactables[0]);
        else
            SetInteractable(null);
    }

    void SetInteractable(Interactable interactable)
    {
        currentInteractable = interactable;
        if (interactable != null)
            InteractableMessage.ShowText(interactable.interactMessage);
        else
            InteractableMessage.HideText();
    }

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    void Update()
    {
        ship.entity.Move(Input.GetAxis("Vertical"));
        ship.entity.Rotate(-Input.GetAxis("Horizontal"));
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ship.Activate(0);
        if (Input.GetKeyUp(KeyCode.Space))
            ship.Deactivate(0);
        if (Input.GetKeyDown(KeyCode.LeftShift))
            ship.Activate(1);
        if (Input.GetKeyUp(KeyCode.LeftShift))
            ship.Deactivate(1);
        if (Input.GetKeyDown(KeyCode.C))
            FindObjectOfType<ComponentsWindow>().Show(ship);
        if (Input.GetKeyDown(KeyCode.I))
            FindObjectOfType<CargoWindow>().Show(ship.inventory);
        if (Input.GetKeyDown(KeyCode.E) && interactables.Count > 0)
            interactables[0].OnInteract(ship);
    }
}
