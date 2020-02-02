using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerType player;
    public float speed;
    private Rigidbody rb;
    private Animator anim;
    public bool seizure;
    private bool check = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        if (seizure == true)
        {
            speed = 0;
            anim.SetBool("FallenTrigger", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void FixedUpdate()
    {
        if (InputManager.Get(InputType.left,player))
        {
            rb.AddForce(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            anim.SetBool("Walking", true);

        }
        else if (InputManager.Get(InputType.right, player))
        {
            rb.AddForce(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            anim.SetBool("Walking", true);
        }
        else if (InputManager.Get(InputType.up, player))
        {
            rb.AddForce(0, 0, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Walking", true);
        }
        else if (InputManager.Get(InputType.down, player))
        {
            rb.AddForce(0, 0, -speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Walking", true);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Walking", false);
        }
        if (Input.GetKey(KeyCode.K))
        {
            seizure = true;
        }
        if (seizure == true)
        {
            speed = 0;
            anim.SetBool("FallenTrigger", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (seizure == false)
        {
            speed = 400;
        }
    }
    private void Update()
    {
        if (seizure == true)
        {
            if (check == false)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Electrocute");
                check = true;
            }
        }
    }
}
