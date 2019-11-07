using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cannon", menuName = "Component/Cannon")]
public class Cannon : Activatable
{
    [Header("Cannon Stats")]
    //Shots per second
    public float damage = 10f;
    public Sound sound;

    [Header("Projectile Stats")]
    public GameObject prefab;
    public float speed = 10f;
    public float ttl = 10f;

    public void Shoot(Transform cannon, Faction faction)
    {
        GameObject obj = Instantiate(prefab, cannon.position, cannon.rotation);
        obj.GetComponent<Projectile>().Setup(damage, speed, ttl, faction);
        SoundHandler.Play(sound, cannon.position);
    }

    public override Activation GetActivation(Ship ship)
    {
        return new Activation(cooldown, null, null, () => { ship.weapons?.Shoot(); });
    }
}
