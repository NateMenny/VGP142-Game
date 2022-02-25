using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]float speediplier = 1f;
    float currentSpeed = 0f;
    [SerializeField] float jumpForce = 100.0f;
    bool isIdle = true;
    [SerializeField] bool isGrounded;

    public float Speediplier { get => speediplier; set => speediplier = value; }
    public float CurrentSpeed { get => currentSpeed; 
        set 
        { 
            currentSpeed = value;
            if (Mathf.Abs(value) < 0.09f) isIdle = true;
            else isIdle = false;
        } 
    }

    public bool IsIdle { get => isIdle; }
    public bool IsGrounded { get => isGrounded; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement Input and execution

        CurrentSpeed = Input.GetAxis("Vertical");
        // Forward
        if (CurrentSpeed > 0f)
            transform.Translate(CurrentSpeed * Speediplier * Time.deltaTime * Vector3.forward);
        //Backward
        else if (CurrentSpeed < 0f)
            transform.Translate(CurrentSpeed * (Speediplier/2f)* Time.deltaTime * Vector3.forward);

        // Jump
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }

        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rhInfo;

        if(Physics.Raycast(gameObject.transform.position, Vector3.down, out rhInfo, 0.1f))
        { 
                isGrounded = true;
            
        }
        else isGrounded = false;

        Debug.DrawLine(gameObject.transform.position, transform.position + Vector3.down * 0.03f, Color.red);
    }

}
