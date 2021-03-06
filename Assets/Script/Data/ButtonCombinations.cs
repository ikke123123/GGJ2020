﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Button Combination", menuName = "Button Combination", order = 1)]
public class ButtonCombinations : ScriptableObject
{
    [SerializeField] ButtonAction[] buttonCombinations;
}

[System.Serializable]
public class ButtonAction
{
    [SerializeField] public ButtonType button;
    [SerializeField] public float waitTime;
}
