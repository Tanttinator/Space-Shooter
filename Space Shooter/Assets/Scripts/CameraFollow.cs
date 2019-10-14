using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target = null;
    bool isFollowing = false;
    float z;

    public void StartFollow(GameObject target)
    {
        this.target = target.transform;
        target.GetComponent<Health>().onDeath += StopFollow;
        isFollowing = true;
    }

    public void StopFollow()
    {
        target = null;
        isFollowing = false;
    }

    void Update()
    {
        if(isFollowing)
        {
            Vector3 pos = target.position;
            pos.z = z;
            transform.position = pos;
        }
    }

    private void Awake()
    {
        z = transform.position.z;
    }
}
