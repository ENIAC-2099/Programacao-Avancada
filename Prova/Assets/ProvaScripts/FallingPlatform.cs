using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FallingPlatform : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("...");

            AtivarQuedaServerRpc();
            Destroy(gameObject,1);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void AtivarQuedaServerRpc()
    {
        AtivarQuedaClientRpc();
    }

    [ClientRpc]
    void AtivarQuedaClientRpc()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
