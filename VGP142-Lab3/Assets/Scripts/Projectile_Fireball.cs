using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Fireball : Projectile
{
    bool hasLaunched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLaunched)
            transform.position += travelSpeed * Time.deltaTime * direction;

        Debug.DrawLine(transform.position, transform.position + direction, Color.red);
    }

    public override void Launch(Vector3 direction_)
    {
        direction = direction_.normalized;
        hasLaunched = true;
        
    }

    public override void OnHit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            other.GetComponent<HealthHandler>().TakeDamage(damage);
            OnHit();
        }
    }
}
