using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int maxLifePoints = 1;
    private int lifePoints;

    public int LifePoints { get => lifePoints; }

    protected void Start()
    {
        lifePoints = maxLifePoints;
    }

    // Returns the new value of health
    public virtual int TakeDamage(int damage_)
    {
        lifePoints -= Mathf.Abs(damage_);
        
        return lifePoints;
    }
    public virtual int HealDamage(int amount_)
    {
        lifePoints += Mathf.Abs(amount_);
  
        return lifePoints;
    }

}
