using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject SpawnPos;
    [SerializeField] GameObject Enemy;

    private void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Enemy, SpawnPos.transform.position, Quaternion.identity);

        }
    }

}
