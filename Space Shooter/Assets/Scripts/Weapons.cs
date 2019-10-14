using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Cannon cannon;
    public List<Transform> cannons;
    Faction faction;

    int cannonId = 0;

    float cooldown = 0f;

    public void Shoot()
    {
        if (cannons.Count == 0 || cooldown > 0f)
            return;

        cannon.Shoot(cannons[cannonId], faction);
        cooldown = 1f / cannon.fireRate;
        cannonId++;
        if (cannonId >= cannons.Count)
            cannonId = 0;
    }

    private void Awake()
    {
        faction = GetComponent<FactionContainer>().faction;
    }

    private void Update()
    {
        if (cooldown > 0f)
            cooldown -= Time.deltaTime;
    }
}
