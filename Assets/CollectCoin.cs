using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AddCoin();
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        GameManager.instance.coinCount++;
        GameManager.instance.coinText.text = "Coin: " + GameManager.instance.coinCount;

        GameManager.instance.Save();
    }
}
