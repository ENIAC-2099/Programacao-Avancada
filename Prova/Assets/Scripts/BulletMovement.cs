using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int playerNum;
    float mySpeed = 10f;

    void Update()
    {
        //Move
        transform.position += transform.forward * mySpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Incluir RigidBody no prefab Bullet
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponent<CharacterMovement>().myNumber != playerNum)
        {
            Destroy(collision.gameObject);
        }
    }
}
