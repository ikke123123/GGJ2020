using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    FMOD.Studio.EventInstance Run;
    public PlayerType player;
    public float speed;
    private Rigidbody rb;
    private Animator anim;
    public bool seizure;
    private bool check = false;
    private float walkingspeed;
    private string p = "Puddle";
    private string g = "Ground";
    private float MaterialValue;
    private RaycastHit rh;
    private float distance = 0.3f;
    public LayerMask lm;
    void UpdateStatus()
    {
        
    }
    void PlayRunEvent(string EventPath)
    {
        MaterialCheck();
        FMOD.Studio.EventInstance Run = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Run, transform, GetComponent<Rigidbody>());
        Run.setParameterByName("Material", MaterialValue, false);
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }
    void CallFootsteps()
    {
        UpdateStatus();
        Run.start();
    }
    void MaterialCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out rh, distance, lm))
        {
            if (rh.collider.CompareTag(p))
                MaterialValue = 1;
            else if (rh.collider.CompareTag(g))
                MaterialValue = 2;
            else
                MaterialValue = 1;
        }
        else
            MaterialValue = 1;
    }
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
        walkingspeed = 0.23f;
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
        Run = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
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
