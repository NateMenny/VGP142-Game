using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightDetection : MonoBehaviour
{   
    public bool canSeePlayer;
    // public bool detectEntities;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canSeePlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSeePlayer = false;
        }
    }
}
