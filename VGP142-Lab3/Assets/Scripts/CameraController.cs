using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float cameraRotY = 180f; // Degrees per second
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Input.GetAxis("Mouse X") * cameraRotY*Time.deltaTime * transform.up);
    }
}
