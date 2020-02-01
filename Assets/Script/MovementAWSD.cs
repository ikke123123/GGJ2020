using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAWSD : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Animator anim;
    public bool seizure;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            anim.SetBool("WalkingTriggerLeft", true);
            anim.SetBool("WalkingTriggerRight", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            anim.SetBool("WalkingTriggerRight", true);
            anim.SetBool("WalkingTriggerLeft", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //anim.SetBool("WalkingTrigger", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //anim.SetBool("WalkingTrigger", true);
        }
        else
        {
            anim.SetBool("WalkingTriggerLeft", false);
            anim.SetBool("WalkingTriggerRight", false);
        }
        if (Input.GetKey(KeyCode.H))
        {
            seizure = true;
        }
        if (seizure == true)
        {
            anim.SetBool("Seizure", true);
        }
    }

}
