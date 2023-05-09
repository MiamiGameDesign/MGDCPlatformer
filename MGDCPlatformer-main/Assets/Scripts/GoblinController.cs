using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GoblinController : MonoBehaviour
{
    public GameObject cameraDock;
    public bool onGround;
    public AudioClip jump;
    public AudioSource a;

    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public AudioClip deathSound;
    public void Kill()
    {
        GetComponent<AudioSource>().PlayOneShot(deathSound);
        {
            this.enabled = false;
            Destroy(GetComponent<Animator>());
            Destroy(GetComponent<Rigidbody>());
            foreach (Transform g in transform)
            {
                g.gameObject.AddComponent<MeshCollider>();
                g.GetComponent<MeshCollider>().convex = true;
                g.transform.parent = null;
                g.gameObject.AddComponent<Rigidbody>();
                foreach (Transform f in g.transform)
                {
                    f.gameObject.AddComponent<MeshCollider>();
                    f.GetComponent<MeshCollider>().convex = true;
                    f.transform.parent = null;
                    f.gameObject.AddComponent<Rigidbody>();
                    foreach (Transform e in f.transform)
                    {
                        e.gameObject.AddComponent<MeshCollider>();
                        e.GetComponent<MeshCollider>().convex = true;
                        e.transform.parent = null;
                        e.gameObject.AddComponent<Rigidbody>();
                    }
                }

            }
        }
    }
    private void FixedUpdate()
    {

        lastPos.y = transform.position.y;
        float animSpeedTime = Vector3.Distance(transform.position, lastPos)/Time.fixedDeltaTime;
        if (!onGround)
            animSpeedTime /= 5;
        GetComponent<Animator>().speed = animSpeedTime/10;
        lastPos = transform.position;
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 vel = transform.forward  * 15;
        vel.y = GetComponent<Rigidbody>().velocity.y;
        if (Input.GetMouseButtonDown(0) && onGround)
        {
            a.PlayOneShot(jump);
            vel.y = 15;  
        }
/*        if (transform.position.x > 76 && transform.position.x < 85 && transform.position.z < -215 && transform.position.z > -220 && transform.position.y > 16)
        {

            
        }*/
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        onGround = Physics.Raycast(transform.position, Vector3.down, 1.6f);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        cameraDock.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        cameraDock.transform.eulerAngles = new Vector3(cameraDock.transform.eulerAngles.x, cameraDock.transform.eulerAngles.y, 0);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        
       
            GetComponent<Rigidbody>().velocity = vel;
    }
}
