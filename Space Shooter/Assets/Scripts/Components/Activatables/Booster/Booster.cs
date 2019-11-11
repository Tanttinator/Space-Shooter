using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Booster", menuName = "Component/Booster")]
public class Booster : Activatable
{
    public float speedMod = 1.5f;

    public override Activation GetActivation(Ship ship)
    {
        return new Activation(ship, cooldown, energyCost, energyPerSecond, () => { ship.entity.AddSpeedMod(speedMod); }, () => { ship.entity.RemoveSpeedMod(speedMod); });
    }
}
