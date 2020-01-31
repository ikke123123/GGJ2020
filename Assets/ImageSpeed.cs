using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSpeed : MonoBehaviour
{
    [SerializeField] private Vector3 speed;
    [SerializeField] private float xKill;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (rectTransform.position.x >= xKill) Destroy(gameObject);
        rectTransform.position += speed;
    }
}
