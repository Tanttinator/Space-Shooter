using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected virtual float Speed
    {
        get
        {
            return 5f;
        }
    }
    protected virtual float TurnSpeed
    {
        get
        {
            return 180f;
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
        Move(1);
    }

    public void RotateTowards(Vector2 target)
    {
        Rotate(Mathf.Sign(Vector2.SignedAngle(transform.up, target - (Vector2)transform.position)));
    }
}
