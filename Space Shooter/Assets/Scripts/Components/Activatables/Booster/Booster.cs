using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Booster", menuName = "Component/Booster")]
public class Booster : Activatable
{
    public float speedMod = 1.5f;
    public float duration = 3f;

    public override Activation GetActivation(Ship ship)
    {
        return new Activation(ship, cooldown, (s) => { ship.StartCoroutine(Boost(ship)); });
    }

    IEnumerator Boost(Ship ship)
    {
        ship.entity.AddSpeedMod(speedMod);
        yield return new WaitForSeconds(duration);
        ship.entity.RemoveSpeedMod(speedMod);
    }
}
