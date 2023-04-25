using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textBox;
    float startTime, timeElapsed;
    void Start()
    {
        startTime = Time.time;
    }
    void Update() {
        if (Time.timeScale != 0)
            timeElapsed = (Time.time - startTime) * Time.timeScale;
            textBox.GetComponent<Text>().text = "Time: " + (Mathf.Round(timeElapsed * 100f) / 100f) % 60;
    }
}
