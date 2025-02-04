using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeightedRandomNumber : MonoBehaviour
{
    [SerializeField] int playerLevel = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float randomNumber = Random.Range(0, playerLevel);

            if (randomNumber <= 80)
            {
                Debug.Log("Common");
            }
            else if (randomNumber < 95)
            {
                Debug.Log("UnCommon");
            }
            else if (randomNumber < 100)
            {
                Debug.Log("Rare");
            }
        }
    }
}
