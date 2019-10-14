using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles ship movement
[RequireComponent(typeof(Health), typeof(Weapons))]
public class Ship : MonoBehaviour
{
    public Engine engine;
    Health health;
    Weapons weapons;

    public float Weight
    {
        get
        {
            return engine.weight + health.hull.weight + health.shield.weight + (weapons.cannon != null? weapons.cannon.weight : 0);
        }
    }

    public float Speed
    {
        get
        {
            return engine.speed * 20 / Weight;
        }
    }

    public float TurnSpeed
    {
        get
        {
            return engine.turnSpeed * 200 / Weight;
        }
    }

    public void Move(float direction)
    {
        transform.Translate(Vector3.up * Speed * direction * Time.deltaTime);
    }

    public void Rotate(float direction)
    {
        transform.Rotate(Vector3.forward, TurnSpeed * direction * Time.deltaTime);
    }

    public void MoveTowards(Vector2 target)
    {
        RotateTowards(target);
        /*if (Vector2.Angle(transform.up, target - (Vector2)transform.position) < 90)
            Move(1);*/
        Move(1);
    }

    public void RotateTowards(Vector2 target)
    {
        Rotate(Mathf.Sign(Vector2.SignedAngle(transform.up, target - (Vector2)transform.position)));
    }

    public float Angle(Ship b)
    {
        return Vector2.Angle(transform.up, (Vector2)b.transform.position - (Vector2)transform.position);
    }

    private void Awake()
    {
        health = GetComponent<Health>();
        weapons = GetComponent<Weapons>();
    }
}
