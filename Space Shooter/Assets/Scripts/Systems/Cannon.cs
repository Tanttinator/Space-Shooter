using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FactionContainer))]
public class Cannon : ShipSystem
{
    public CannonData cannon;
    public List<Transform> cannons;
    Faction faction;

    int cannonId = 0;

    protected override void Effect()
    {
        if(cannons.Count == 0)
        {
            Debug.Log(gameObject + " is trying to use a cannon without any linked cannon objects!");
            return;
        }

        cannon.Shoot(cannons[cannonId], faction);

        cannonId++;
        if (cannonId >= cannons.Count)
            cannonId = 0;
    }

    protected override float Cooldown()
    {
        return 1f / cannon.fireRate;
    }

    private void Awake()
    {
        faction = GetComponent<FactionContainer>().faction;
    }
}
