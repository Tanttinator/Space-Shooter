using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : ShipSystem
{
    public float speedMod = 1.25f;
    public float boostTime = 3f;

    protected override void Effect()
    {
        StartCoroutine(BoostEffect());
    }

    IEnumerator BoostEffect()
    {
        owner.speed *= speedMod;
        yield return new WaitForSeconds(boostTime);
        owner.speed /= speedMod;
    }
}
