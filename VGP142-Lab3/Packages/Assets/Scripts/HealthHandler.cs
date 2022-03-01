using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int maxLifePoints = 1;
    private int lifePoints;

    // Invincibility Stuff
    private bool isInvincible = false;
    private float? invincibilityLimit;
    private float invincibilityCounter = 0f;

    public int LifePoints { get => lifePoints; }

    protected void Start()
    {
        lifePoints = maxLifePoints;
    }

    private void Update()
    {
        if(isInvincible)
        {
            invincibilityCounter += Time.deltaTime;
            if (invincibilityCounter >= invincibilityLimit)
            {
                invincibilityCounter = 0f;
                isInvincible = false;
            }
        }
    }

    // Returns the new value of health
    public virtual int TakeDamage(int damage_)
    {
        if (isInvincible) return lifePoints;

        lifePoints -= Mathf.Abs(damage_);
        
        return lifePoints;
    }
    public virtual int HealDamage(int amount_)
    {
        if (isInvincible) return lifePoints;

        lifePoints += Mathf.Abs(amount_);
  
        return lifePoints;
    }

    public void BecomeInvincible()
    {
        isInvincible = true;
        // Maybe do a particle thing or something
    }

    private void VariableCheck()
    {
        if (invincibilityLimit == null) invincibilityLimit = 1f;
    }
}
