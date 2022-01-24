using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    CharacterController controller;
    float health = 100;

    public GameObject characterObject;
    private GameObject willThrowAnException;
    Animator anim;



    [Header("Player Settings")]
    [Space(10)]
    [Tooltip("Speed value between 1 and 6")]
    [Range(1.0f, 6.0f)]
    public float speed = 6;
    public float gravity = 9.81f;
    public float jumpSpeed = 10.0f;


    enum ControllerType { SimpleMove, Move }
    [SerializeField] ControllerType type;

    Vector3 moveDirection;
    public bool canMove = true;

    public bool godModeActive = false;
    public float godModeTimer = 3.0f;

    public float jumpMultipler = 2.0f;
    public float jumpModeTimer = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
            controller = GetComponent<CharacterController>();

            controller.minMoveDistance = 0.0f;

            if (speed <= 0)
            {
                speed = 6.0f;
                throw new UnassignedReferenceException("Speed not set on " + name + " defaulting to " + speed);
            }

            if (jumpSpeed <= 0)
            {
                jumpSpeed = 6.0f;

                Debug.Log("JumpSpeed not set on " + name + " defaulting to " + jumpSpeed);
            }

            if (gravity <= 0)
            {
                gravity = 9.81f;

                Debug.Log("Gravity not set on " + name + " defaulting to " + gravity);
            }

            moveDirection = Vector3.zero;


            if (!characterObject)
                Debug.LogWarning("Missing character object on " + name);
            else
            {
                anim = characterObject.GetComponent<Animator>();
                if (!anim)
                    Debug.LogWarning("Missing animator on " + characterObject.name);
            }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case ControllerType.SimpleMove:
                controller.SimpleMove(transform.forward * Input.GetAxis("Vertical") * speed);

                break;
            case ControllerType.Move:

                if (controller.isGrounded && canMove)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDirection *= speed;

                    moveDirection = transform.TransformDirection(moveDirection);
                    if (Input.GetButtonDown("Jump"))
                        moveDirection.y = jumpSpeed;
                }

                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);

                break;
        }

        try
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Attack");
                canMove = false;
                moveDirection = Vector3.zero;
            }
            //Fire();

            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetTrigger("Die");
                canMove = false;
                moveDirection = Vector3.zero;
            }

            string nope = willThrowAnException.name;
        
            anim.SetBool("isGrounded", controller.isGrounded);
            anim.SetFloat("Speed", transform.InverseTransformDirection(controller.velocity).z);
        }
        catch (NullReferenceException e)
        {
            Debug.Log("You're trying to access something that doesnt exist. \n Error: " +
                e.Message);
        }
        catch (MissingComponentException e)
        {
            Debug.Log("You forgot to put the anim component on idiot. \n"
                + e.Message);
        }
    }

    [ContextMenu("Reset Stats")]
    void ResetStats()
    {
        speed = 6.0f;
    }
}
