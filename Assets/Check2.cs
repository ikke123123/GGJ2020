using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check2 : MonoBehaviour
{
    public GameObject otherObject1;
    public GameObject otherObject2;
    Animator otherAnimator1;
    Animator otherAnimator2;
    public bool check1;
    // Start is called before the first frame update
    void Start()
    {
        otherAnimator1 = otherObject1.GetComponent<Animator>();
        otherAnimator2 = otherObject2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            //Debug.Log("ConveyerCollision");
            check1 = true;
        }
        if (other.gameObject.name == "Player1")
        {
             otherAnimator1.SetBool("Work", true);
        }
        if (other.gameObject.name == "Player2")
        {
           otherAnimator2.SetBool("Work", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            //Debug.Log("ConveyerCollisionOut");
            check1 = false;
        }
        if (other.gameObject.name == "Player1")
        {
            otherAnimator1.SetBool("Work", false);
        }
        if (other.gameObject.name == "Player2")
        {
            otherAnimator2.SetBool("Work", false);
        }
    }
}
