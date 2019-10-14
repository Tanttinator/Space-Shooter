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
        if (Input.GetKey(KeyCode.Space) && ship.HasWeapons)
            ship.weapons.Shoot();
    }
}
