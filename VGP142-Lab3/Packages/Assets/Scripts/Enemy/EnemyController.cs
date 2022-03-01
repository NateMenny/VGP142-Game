using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]GameObject model;
    EnemySightDetection esd;
    ProjectileLauncher pl;
    Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] droppableItems;

    float timeSinceLastFire = 0f;
    float fireRate = 1f;

    public GameObject Player { get => player;}

    // Start is called before the first frame update
    void Start()
    {
        if(!(esd=GetComponentInChildren<EnemySightDetection>()))
        {
            Debug.Log("There is no sight detection on " + name);
        }

        if(!(pl=GetComponentInChildren<ProjectileLauncher>()))
        {
            Debug.Log("There is no projectile launcher on " + name);
        }

        if (!(animator = GetComponentInChildren<Animator>()))
        {
            Debug.Log("There is no animator on " + name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", GetComponent<NavMeshAgent>().velocity.magnitude);

        if (esd.canSeePlayer)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Debug.DrawLine(transform.position, transform.position + direction, Color.red);

            //model.SetActive(true);
            if (timeSinceLastFire > fireRate)
            {
                pl.FireProjectile(direction);
                animator.SetTrigger("doAttack");
                timeSinceLastFire = 0f;
            }
        }
        //else model.SetActive(false);

        timeSinceLastFire += Time.deltaTime;

        if (GetComponent<HealthHandler>().LifePoints <= 0) Die();
    }

    // Triggers the punched animation
    public void IGotPunched()
    {
        animator.SetTrigger("hitByPunch");
    }
    public void IGotKicked()
    {
        animator.SetTrigger("hitByKick");
    }
    public void IGotShot()
    {
        animator.SetTrigger("hitByShot");
    }

    void Die()
    {
        animator.SetTrigger("hasDied");
        if (droppableItems.Length > 0)
        {
            int randNum = Random.Range(0, droppableItems.Length);
            Instantiate(droppableItems[randNum], transform.position, transform.rotation);
        }
        Destroy(gameObject, 1f);
    }
}
