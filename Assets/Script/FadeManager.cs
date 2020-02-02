using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public float stopFadeX;
    public float startFadeX;
    public float fadeEndStop;
    public bool selfDestruct = false;

    private float startX;
    private RectTransform rt;
    private Image image;
    private bool firstRun = true;

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
            
        }
        else
        {
            image.color = CodeLibrary.ConvertToTransparent(image.color, 1);
        }

        if (selfDestruct)
        {
            if (firstRun)
            {
                startFadeX = rt.localPosition.x;
                fadeEndStop = rt.localPosition.x + 50;
                firstRun = false;
            }
            image.color = CodeLibrary.ConvertToTransparent(image.color, CodeLibrary.Reverse(CodeLibrary.Remap(rt.localPosition.x, startFadeX, fadeEndStop, 0, 10f)));
            if (image.color.a <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
