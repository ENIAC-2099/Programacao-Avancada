using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Jump : NetworkBehaviour
{
    public Rigidbody rb;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            rb.AddForce(Vector3.up * 500);
        }
    }
}
