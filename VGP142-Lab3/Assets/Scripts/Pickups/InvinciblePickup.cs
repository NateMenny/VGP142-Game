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
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        if(GetComponent<ParticleSystem>())
        {
            GetComponent<ParticleSystem>().Play();
        }

        Destroy(gameObject, 2f);
    }
}
