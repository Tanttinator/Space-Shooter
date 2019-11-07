using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "Component/Spawner")]
public class Spawner : Activatable
{
    public GameObject ship;

    public override Activation GetActivation(Ship ship)
    {
        return new Activation(cooldown, () => { Instantiate(this.ship, ship.transform.position, ship.transform.rotation); });
    }
}
