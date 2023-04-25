using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalPost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("GoblinController"))
        {
            Application.Quit();
        }
    }
}
