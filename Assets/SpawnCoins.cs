using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coins;
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine("Points", 1.5f);
    }

    private IEnumerator Points(float duration)
    {
        float normalizedTime = 0;

        while (normalizedTime <= 1f)
        {
            GameObject coin = Instantiate(coins, spawnPoints
            [Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

            normalizedTime += Time.deltaTime / duration;
            yield return new WaitForSeconds(3f);
        }
    }
}
