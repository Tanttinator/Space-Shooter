using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Pickup : MonoBehaviour
{
    public Sound pickupSound;

    protected virtual bool OnPickup(GameObject obj)
    {
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnPickup(collision.gameObject))
        {
            if (pickupSound != null)
                SoundHandler.Play(pickupSound, transform.position);
            Destroy(gameObject);
        }
    }
}
