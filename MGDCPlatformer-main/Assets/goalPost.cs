using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goalPost : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI youwin;
    private void OnTriggerEnter(Collider other)
    {
            image.enabled = true;
            youwin.enabled = true;
            Time.timeScale = 0;
    }
}
