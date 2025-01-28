using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] int playerLevel = 1;

    private void OnTriggerEnter(Collider cc)
    {
        if (cc.gameObject.tag == "Loot")
        {
            Debug.Log("Touched Loot");

            Destroy(cc.gameObject);

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
