using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum EObstacleType
    {
        DAMAGE,
        SLOW,
        DAMAGEANDSLOW
    }
    delegate void TriggerObstacle(GameObject entity_);

    public int valueOfAbility;
    public EObstacleType myType;
    TriggerObstacle activationFunction;

   
    // Start is called before the first frame update
    void Start()
    {
        if (valueOfAbility == 0) valueOfAbility = 1;

        switch(myType)
        {
            case EObstacleType.DAMAGE:
                activationFunction = DealDamageToPlayer;
                break;
            case EObstacleType.SLOW:
                activationFunction = SlowdownPlayer;
                break;
            case EObstacleType.DAMAGEANDSLOW:
                activationFunction = DealDamageToPlayer;
                activationFunction += SlowdownPlayer;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            activationFunction(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(myType == EObstacleType.SLOW || myType == EObstacleType.DAMAGEANDSLOW)
            {
                other.GetComponent<PlayerMovement>().Speediplier = other.GetComponent<PlayerMovement>().Speediplier * valueOfAbility;
            }
        }
    }

    void DealDamageToPlayer(GameObject entity_)
    {
        entity_.GetComponent<HealthHandler>().TakeDamage(valueOfAbility);
    }

    void SlowdownPlayer(GameObject entity_)
    {
        entity_.GetComponent<PlayerMovement>().Speediplier = entity_.GetComponent<PlayerMovement>().Speediplier/valueOfAbility;
    }
}
