using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JumpPad : MonoBehaviour
{
    public float strength = 20;
    public AudioClip jump;
    public AudioSource a;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            a.PlayOneShot(jump);
            rb.velocity = new Vector3(rb.velocity.x, strength, rb.velocity.z);
            
        } 
    }
}
