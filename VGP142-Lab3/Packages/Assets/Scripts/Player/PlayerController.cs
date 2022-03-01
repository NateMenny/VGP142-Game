using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject blueGreatsword;
    [SerializeField] GameObject greyGreatsword;

    int combatPoints;
    int knowledgePoints;

    PlayerMovement pm;

    [Header("Animation Variables")]
    [SerializeField] Animator animCont;
    [SerializeField] float gestureDelay = 5f; // Time in seconds to wait before doing idle gesture
    bool isAttacking = false;
    bool isDead = false;
    float idleTime = 0f; // Set - 0 after reaching time to do gesture
    float attackDuration = 0f;
    float attackTimer = 0f;

    public int CombatPoints { get => combatPoints; set => combatPoints = value; }
    public int KnowledgePoints { get => knowledgePoints; set => knowledgePoints = value; }

    // Start is called before the first frame update
    void Start()
    {
        if(!(animCont=GetComponentInChildren<Animator>()))
        {
            Debug.Log("Player does not have anim controller");
        }

        if (!(pm=GetComponent<PlayerMovement>()))
        {
            Debug.Log("Player does not have movement script");
        }

        blueGreatsword.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Animation logic
        UpdateAnimatorVariables();

        if (pm.IsIdle)
        {
            idleTime += Time.deltaTime;
            if (idleTime > gestureDelay)
            { 
                animCont.SetTrigger("doGesture");
                idleTime = 0f;
            }
        }
        else idleTime = 0f;

        if (GetComponent<HealthHandler>().LifePoints <= 0 && !isDead)
        {
            Die();
        }

        // Attacking Logic
        if (isAttacking)
        {
            GetComponent<PlayerMovement>().enabled = false;
            attackTimer += Time.deltaTime;
        }
        else if(!isAttacking && !isDead)
        {
            GetComponent<PlayerMovement>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Mouse0)) ExecuteHiltAttack();
            else if (Input.GetKeyDown(KeyCode.Mouse1)) ExecuteSwingAttack();
        }

        if (attackTimer >= attackDuration)
        {
            attackTimer = 0f;
            attackDuration = 0f;
            isAttacking = false;
        }
    }

    void UpdateAnimatorVariables()
    {
        animCont.SetFloat("speed", pm.CurrentSpeed);
        animCont.SetBool("inAir", !pm.IsGrounded);
    }

    void Die()
    {
        isDead = true;
        animCont.SetTrigger("hasDied");
        GetComponent<PlayerMovement>().enabled = false;
        Destroy(gameObject, animCont.GetCurrentAnimatorStateInfo(0).length);
    }

    void ExecuteHiltAttack()
    {
        isAttacking = true;
        animCont.SetTrigger("doHiltAttack");
        attackDuration = animCont.GetCurrentAnimatorStateInfo(0).length;
    }

    void ExecuteSwingAttack()
    {
        isAttacking = true;
        animCont.SetTrigger("doSwingAttack");
        attackDuration = animCont.GetCurrentAnimatorStateInfo(0).length;
    }

    public void EquipBlueGreatsword()
    {
        greyGreatsword.SetActive(false);
        blueGreatsword.SetActive(true);
    }

    public void EquipGreyGreatsword()
    {
        greyGreatsword.SetActive(true);
        blueGreatsword.SetActive(false);
    }
}
