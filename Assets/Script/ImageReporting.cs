using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageReporting : MonoBehaviour
{
    [HideInInspector] public Rect rect;
    [HideInInspector] public ImageManager imageManager;
    [HideInInspector] public float minX;
    [HideInInspector] public float maxX;

    private RectTransform rt;

    private void OnEnable()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rt.localPosition.x >= maxX)
        {
            imageManager.ReachedEnd(gameObject);
        }
        if (CodeLibrary.RectOverlap(rt, rect))
        {
            imageManager.ReportOverlap(gameObject);
        }
    }
}
