using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject otherObject1;
    public GameObject otherObject2;
    Animator otherAnimator1;
    Animator otherAnimator2;
    public bool check1;
    public Check2 check2;
    // Start is called before the first frame update
    void Start()
    {
        otherAnimator1 = otherObject1.GetComponent<Animator>();
        otherAnimator2 = otherObject2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check2.check1 == true && check1 == true)
        {
            //Debug.Log("Both players collide");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            //Debug.Log("TableCollision");
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
            //Debug.Log("TableCollision");
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
