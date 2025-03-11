using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    float timerTime;

    void Update()
    {
        timerTime += Time.deltaTime;
        timerText.text = timerTime.ToString("f2");
    }
}
