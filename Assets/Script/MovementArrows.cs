using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrows : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Animator anim;
    public bool seizurep2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Walking", true);
        }else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Walking", false);
        }
        if (Input.GetKey(KeyCode.K))
        {
            seizurep2 = true;
        }
        if (seizurep2 == true)
        {
            speed = 0;
            anim.SetBool("FallenTrigger", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (seizurep2 == false)
        {
            speed = 100;
        }
    }
}

