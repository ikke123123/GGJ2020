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
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Walking", true);
        }else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Walking", false);
        }
        if (Input.GetKey(KeyCode.L))
        {
            seizurep1 = true;
        }
        if (seizurep1 == true)
        {
            speed = 0;
            anim.SetBool("FallenTrigger", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (seizurep1 == false)
        {
            speed = 80;
        }
    }
}
