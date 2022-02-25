using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base projectile class - Should never be used as component
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float travelSpeed = 1f;
    protected Vector3 direction;
    [SerializeField] protected int damage = 1;
    public abstract void OnHit();
    public abstract void Launch(Vector3 direction_);
}

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField] GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireProjectile(Vector3 direction_)
    {
        GameObject launchedProjectile = Instantiate(projectile, transform.position, transform.rotation);
        launchedProjectile.GetComponent<Projectile>().Launch(direction_);
    }
}
