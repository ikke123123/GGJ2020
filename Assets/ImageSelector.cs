using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSelector : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetImage(int num)
    {
        num = Mathf.Clamp(num, 0, sprites.Length - 1);
        image.sprite = sprites[num];
    }
}
