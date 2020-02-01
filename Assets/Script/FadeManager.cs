using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [HideInInspector] public float stopFadeX;
    [HideInInspector] public float startFadeX;
    [HideInInspector] public float border;

    private float startX;
    private float target;
    private float fadeEndStop;
    private RectTransform rt;
    private Image image;

    private void OnEnable()
    {
        rt = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        startX = rt.localPosition.x;
    }

    private void Update()
    {
        if (rt.localPosition.x < stopFadeX)
        {
            image.color = CodeLibrary.ConvertToTransparent(image.color, CodeLibrary.Remap(rt.localPosition.x, startX, stopFadeX, 0, 1));
            return;
        }
        //if (rt.localPosition.x > )
        //{

        //}
        if (rt.localPosition.x > stopFadeX)
        {
            image.color = CodeLibrary.ConvertToTransparent(image.color, 1);
            startX = startFadeX;
        }
    }
}
