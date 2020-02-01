using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [HideInInspector] public float stopFadeX;
    [HideInInspector] public float startFadeX;
    [HideInInspector] public float fadeEndStop;

    private float startX;
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
        if (rt.localPosition.x <= stopFadeX)
        {
            image.color = CodeLibrary.ConvertToTransparent(image.color, CodeLibrary.Remap(rt.localPosition.x, startX, stopFadeX, 0, 2.5f));
        }
        else if (rt.localPosition.x >= startFadeX)
        {
            image.color = CodeLibrary.ConvertToTransparent(image.color, CodeLibrary.Reverse(CodeLibrary.Remap(rt.localPosition.x, startFadeX, fadeEndStop, 0, 10f)));
        }
        else
        {
            image.color = CodeLibrary.ConvertToTransparent(image.color, 1);
        }
        
        //if (rt.localPosition.x > )
        //{

        //}
        //if (rt.localPosition.x > stopFadeX)
        //{
        //    image.color = CodeLibrary.ConvertToTransparent(image.color, 1);
        //    startX = startFadeX;
        //}
    }
}
