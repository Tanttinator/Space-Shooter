using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles player movement
[RequireComponent(typeof(Ship))]
public class PlayerController : MonoBehaviour
{
    Ship ship;
    Weapons weapons;

    private void Awake()
    {
        ship = GetComponent<Ship>();
        weapons = GetComponent<Weapons>();
    }

    void Update()
    {
        ship.Move(Input.GetAxis("Vertical"));
        ship.Rotate(-Input.GetAxis("Horizontal"));
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            weapons.Shoot();
    }
}
