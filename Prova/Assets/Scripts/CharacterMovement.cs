using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CharacterMovement : NetworkBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    int speed = 5;
    int rotationspeed = 20;

    public int myNumber;

    //Similar a um Start ou Awaken, mas funciona melhor em rede
    public override void OnNetworkSpawn()
    {
        myNumber = (int)NetworkObject.NetworkObjectId;
    }

    void Update()
    {
        if (!IsOwner)
            return;

        //Move
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, rotationspeed * Time.deltaTime * -rotationspeed, 0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, rotationspeed * Time.deltaTime * rotationspeed, 0f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }

        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            FireServerRpc();
        }
    }
    void Fire()
    {
        BulletMovement bullet = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<BulletMovement>();
        bullet.playerNum = myNumber;
    }

    //Informacao de tiro mandada para o servidor/host
    [ServerRpc]
    void FireServerRpc()
    {
        FireClientRpc();
    }

    //Informacao de tiro mandada para todo cliente (incluindo host)
    [ClientRpc]
    void FireClientRpc()
    {
        Fire();
    }
}
