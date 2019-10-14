using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FactionContainer))]
public class Cannon : ShipSystem
{
    public GameObject projectile;
    public List<Transform> cannons;

    int cannonId = 0;

    private void Awake()
    {
        if (projectile.GetComponent<Projectile>() == null)
            Debug.LogError(gameObject.name + " has been assigned a projectile object without a projectile script!");
    }

    protected override void Effect()
    {
        if(cannons.Count == 0)
        {
            Debug.Log(gameObject + " is trying to use a cannon without any linked cannon objects!");
            return;
        }

        GameObject obj = Instantiate(projectile, cannons[cannonId].position, transform.rotation);
        obj.GetComponent<Projectile>().Setup(GetComponent<FactionContainer>().faction);

        cannonId++;
        if (cannonId >= cannons.Count)
            cannonId = 0;
    }
}
