using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class killPlayer : MonoBehaviour
{
    float RestartTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GoblinController>() && RestartTime == 0)
        {
            other.gameObject.GetComponent<GoblinController>().Kill();
            RestartTime = Time.realtimeSinceStartup + 3;
            
        }
    }
    private void Update()
    {
        if (Time.realtimeSinceStartup > RestartTime && RestartTime != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
