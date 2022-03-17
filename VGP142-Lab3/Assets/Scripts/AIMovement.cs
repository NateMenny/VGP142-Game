using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public enum MoveType
    {
        PATROL
    }

    public MoveType moveType;
    public float stopDistance = 0;
    [SerializeField] float? chaseRadius = null;

    [SerializeField] Transform[] patrolPositions;
    int currentDestinationIndex = 0;

    public Transform[] PatrolPositions { get => patrolPositions; set => patrolPositions = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (!chaseRadius.HasValue) chaseRadius = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Player)
        {
            if (GetComponentInChildren<EnemySightDetection>().canSeePlayer)
            {
                GetComponent<NavMeshAgent>().stoppingDistance = 2f;
                ChaseTarget(GameManager.Instance.Player.transform.position);
            }
            else
            {
                GetComponent<NavMeshAgent>().stoppingDistance = 0f;
                FollowPatrolPath();
            }
        }

    }

    void FollowPatrolPath()
    {
        GetComponent<NavMeshAgent>().SetDestination(patrolPositions[currentDestinationIndex].position);

        if (Vector3.Distance(transform.position, patrolPositions[currentDestinationIndex].position) <= stopDistance)
        {
            if (++currentDestinationIndex == patrolPositions.Length)
                currentDestinationIndex = 0;

        }
    }

    void ChaseTarget(Vector3 targetPosition_)
    {
        GetComponent<NavMeshAgent>().SetDestination(targetPosition_);
        
    }
}
