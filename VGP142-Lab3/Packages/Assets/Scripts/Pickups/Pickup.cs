using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all pickups
public abstract class Pickup : MonoBehaviour
{
    [SerializeField] protected List<string> tagsThatCanPMU;

    // Start is called before the first frame update

    public abstract void OnPickup(Collider other);

    protected void OnTriggerEnter(Collider other)
    {
        if (tagsThatCanPMU.Count == 0) return;

        foreach(string tag in tagsThatCanPMU)
        {
            if(other.CompareTag(tag))
            {
                OnPickup(other);
            }
        }
    }
}
