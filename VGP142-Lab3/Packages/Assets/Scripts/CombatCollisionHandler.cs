using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCollisionHandler : MonoBehaviour
{
    public int damage = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponent<HealthHandler>().TakeDamage(damage));
    }
}
