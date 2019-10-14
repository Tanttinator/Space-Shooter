using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles player movement
[RequireComponent(typeof(Ship))]
public class PlayerController : MonoBehaviour
{
    Ship ship;

    public ShipSystem[] systems;

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    void Update()
    {
        ship.Move(Input.GetAxis("Vertical"));
        ship.Rotate(-Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.Space) && systems.Length > 0)
            systems[0].Activate();
    }
}
