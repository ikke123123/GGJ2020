using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSmasherManager : MonoBehaviour
{
    [Header("Images")]
    [SerializeField] private ImageSelector imageSelector;
    [SerializeField] private ImageManager imageManager;
    [SerializeField] private RectTransform circle;
    [SerializeField] private RectTransform x;

    [Header("Settings")]
    [SerializeField] public PlayerType playerType;
    [SerializeField] private float increasePerTime;
    [SerializeField] private float onPressChange;

    [Header("Debugging")]
    [SerializeField] private Vector3 stockScale;
    [SerializeField] private Vector3 bigScale = new Vector3(1, 1, 1);
    [SerializeField] private float currentLevel;
    [SerializeField] public bool disabled;
    [SerializeField] private InputType lastInput;

    private void Awake()
    {
        lastInput = InputType.circle;
        stockScale = circle.localScale;
    }

    private void FixedUpdate()
    {
        if (disabled == false)
        {
            ToggleObjects(true);
            currentLevel = Mathf.Clamp(currentLevel + increasePerTime, 0, 8);
            imageSelector.SetImage(Mathf.RoundToInt(currentLevel));
            imageManager.speedModifier = CodeLibrary.Remap(currentLevel, 0, 8, 0.1f, 1);
        } else
        {
            ToggleObjects(false);
            currentLevel = 0;
            lastInput = InputType.circle;
        }
    }

    private void Update()
    {
        if (AlternatingButton() && disabled == false) currentLevel += onPressChange;
    }

    private void ToggleObjects(bool set)
    {
        circle.gameObject.SetActive(set);
        x.gameObject.SetActive(set);
        imageSelector.gameObject.SetActive(set);
    }

    private bool AlternatingButton()
    {
        if (lastInput == InputType.circle)
        {
            circle.localScale = stockScale;
            x.localScale = bigScale;
            if (InputManager.Get(InputType.x, playerType, PressType.down))
            {
                lastInput = InputType.x;
                return true;
            }
            return false;
        }
        else
        {
            x.localScale = stockScale;
            circle.localScale = bigScale;
            if (InputManager.Get(InputType.circle, playerType, PressType.down))
            {
                lastInput = InputType.circle;
                return true;
            }
            return false;
        }
    }
}
