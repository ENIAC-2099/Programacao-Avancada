using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 8;
    public CharacterController myController;

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            myController.Move(new Vector3(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            myController.Move(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, 0f));
        }
    }
}

