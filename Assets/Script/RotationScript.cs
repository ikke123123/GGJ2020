using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(rotationSpeed);
    }
}
