using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerControllerFPSArena : NetworkBehaviour 
{
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Move
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        //Sprint
        bool sprintInput = Input.GetKey(KeyCode.LeftShift);

        if (sprintInput == true)
        {
            speed = 10;
            
        }
        if (sprintInput == false)
        {
            speed = 5;
        }

        // Rotation
        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                toRotation, rotationSpeed * Time.deltaTime);
        }

    }
}
