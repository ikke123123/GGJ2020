using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAWSD : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Animator anim;
    public bool seizurep1;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * speed, 0, 0);
            anim.SetBool("WalkingTriggerRight", true);
            anim.SetBool("WalkingTriggerLeft", false);
            anim.SetBool("WalkingTriggerUp", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * speed, 0, 0);
            anim.SetBool("WalkingTriggerLeft", true);
            anim.SetBool("WalkingTriggerRight", false);
            anim.SetBool("WalkingTriggerUp", false);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(0, 0, Input.GetAxis("Vertical") * speed);
            anim.SetBool("WalkingTriggerRight", false);
            anim.SetBool("WalkingTriggerLeft", false);
            anim.SetBool("WalkingTriggerUp", true);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(0, 0, Input.GetAxis("Vertical") * speed);
            anim.SetBool("WalkingTriggerRight", false);
            anim.SetBool("WalkingTriggerLeft", false);
            anim.SetBool("WalkingTriggerUp", false);
        }
        else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            anim.SetBool("WalkingTriggerRight", false);
            anim.SetBool("WalkingTriggerLeft", false);
            anim.SetBool("WalkingTriggerUp", false);
        }
        if (Input.GetKey(KeyCode.L))
        {
            seizurep1 = true;
        }
        if (seizurep1 == true)
        {
            anim.SetBool("Seizure", true);
            anim.SetBool("WalkingTriggerLeft", false);
            anim.SetBool("WalkingTriggerUp", false);
            anim.SetBool("WalkingTriggerRight", false);
        }
    }
}
