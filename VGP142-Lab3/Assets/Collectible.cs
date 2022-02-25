using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Do something
        other.GetComponent<HealthHandler>().HealDamage(value);

        // Destory self
        Destroy(gameObject, 0.2f);
    }
}
