using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Vehicle
{
    public GameObject targetHuman;
    protected override void ClacSteeringForce()
    {
        ApplyForce(Seek(targetHuman));
    }
}
