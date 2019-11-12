using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    public string interactMessage;

    public virtual void OnInteract(Ship ship)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if(controller != null)
        {
            controller.AddInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.RemoveInteractable(this);
        }
    }
}
