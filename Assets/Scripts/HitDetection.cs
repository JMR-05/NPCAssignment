using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Hit");
            Time.timeScale = 0;
        }
    }
}
