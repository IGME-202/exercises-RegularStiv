using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Vehicle
{
    // fix camera glitch
    public GameObject targetZombie;
    public Treasure targetTreasure;
    protected override void ClacSteeringForce()
    {
        Vector3 uForce = Vector3.zero;

        uForce += Seek(targetTreasure.gameObject);
        uForce += Flee(targetZombie);

        uForce = Vector3.ClampMagnitude(uForce, maxForce);

        ApplyForce(uForce);
    }

    protected override void Update()
    {
        base.Update();

        if (Vector3.Distance(position, targetTreasure.transform.position) < radius)
        {
            targetTreasure.OnGrab();
        }
    }
}
