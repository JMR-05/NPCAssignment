using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostColors : MonoBehaviour
{
    //float duration = 1.0f;
    //Color color0 = Color.red;
    //Color color1 = Color.blue;

    Light lt;

    private void Start()
    {
        lt = GetComponent<Light>();
        //Color newColor = new Color(1f, 1f, 1f);
    }

    /*private void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }*/

    private void OnTriggerEnter(Collider cc)
    {
        if (cc.gameObject.tag == "Player")
        {
            //Color newColor = new Color(0.8f, 0.7f, 0.3f);
            lt.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider cc)
    {
        
    }
}
