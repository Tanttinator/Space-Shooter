using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles player movement
[RequireComponent(typeof(Ship))]
public class PlayerController : MonoBehaviour
{
    Ship ship;

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
    }
}
