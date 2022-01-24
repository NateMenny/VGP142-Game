using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_TimeBased : MonoBehaviour
{
    public float damage;
    public float damageTime;
    float timeSinceLastDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (damage <= 0)
            damage = 5.0f;

        if (damageTime <= 0)
            damageTime = 2.0f;
    }
}
