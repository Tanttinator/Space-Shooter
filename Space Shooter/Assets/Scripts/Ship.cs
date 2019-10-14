using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityShip), typeof(HealthShip))]
public class Ship : MonoBehaviour
{
    public Hull hull;
    public Engine engine;
    public Cannon cannon;
    public Shield shield;

    public EntityShip entity { get; protected set; }
    public HealthShip health { get; protected set; }
    public Weapons weapons { get; protected set; }

    public bool HasWeapons
    {
        get
        {
            return weapons != null;
        }
    }
    public float Weight
    {
        get
        {
            return (hull != null ? hull.weight : 20) + (engine != null ? engine.weight : 3) + (cannon != null ? cannon.weight : 5) + (shield != null ? shield.weight : 5);
        }
    }

    private void Awake()
    {
        entity = GetComponent<EntityShip>();
        health = GetComponent<HealthShip>();
        weapons = GetComponent<Weapons>();
    }
}
