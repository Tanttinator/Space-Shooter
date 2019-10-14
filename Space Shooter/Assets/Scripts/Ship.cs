using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles ship movement
public class Ship : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 10f;

    public void Move(float direction)
    {
        transform.Translate(Vector3.up * speed * direction * Time.deltaTime);
    }

    public void Rotate(float direction)
    {
        transform.Rotate(Vector3.forward, turnSpeed * direction * Time.deltaTime);
    }
}
