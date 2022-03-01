using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeIncreaseCollectible : Pickup
{
    public int value;

    public override void OnPickup(Collider other)
    {
        other.GetComponent<PlayerController>().KnowledgePoints += value;
        Destroy(gameObject);
    }
}
