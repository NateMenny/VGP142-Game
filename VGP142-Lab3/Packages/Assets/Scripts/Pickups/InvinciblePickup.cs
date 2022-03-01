using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePickup : Pickup
{
    public override void OnPickup(Collider other)
    {
        HealthHandler hh;

        if (hh = other.GetComponent<HealthHandler>())
            hh.BecomeInvincible();

        Destroy(gameObject);
    }
}
