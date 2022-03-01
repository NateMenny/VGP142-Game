using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCollectible : Pickup
{
    public int value = 0;
    
    public override void OnPickup(Collider other)
    {
        other.GetComponent<HealthHandler>().HealDamage(value);
        //Debug.Log("Playe Health: " + other.GetComponent<HealthHandler>().LifePoints);
        Destroy(gameObject, 0.2f);
    }
}
