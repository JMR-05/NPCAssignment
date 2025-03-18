using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotions : MonoBehaviour
{
    Light lt;

    Coroutine yellow;
    Coroutine blue;
    Coroutine red;

    private void Start()
    {
        lt = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider cc)
    {
        if (cc.gameObject.tag == "Player")
        {
            yellow = StartCoroutine(Yellow());

            if (blue != null)
            {
                StopCoroutine(blue);
            }
            if (red != null)
            {
                StopCoroutine(red);
            }
        }
    }

    private void OnTriggerExit(Collider cc)
    {
        if (cc.gameObject.tag == "Player")
        {
            StopCoroutine(yellow);
            blue = StartCoroutine(Blue());
            red = StartCoroutine(Red());
        }
    }

    public IEnumerator Yellow()
    {
        yield return new WaitForSeconds(10);
        lt.color = new Color32(204, 178, 76, 255);
    }

    public IEnumerator Blue()
    {
        yield return new WaitForSeconds(3f);
        lt.color = new Color32(19, 83, 154, 255);
    }

    public IEnumerator Red()
    {
        yield return new WaitForSeconds(10f); //Change after testing.
        lt.color = new Color32(123, 10, 10, 255);
    }
}
