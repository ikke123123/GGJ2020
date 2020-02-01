using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTester : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(ReturnChosen(KeyCode.Joystick2Button0, PressType.continuous) + KeyCode.Joystick2Button0.ToString());
        Debug.Log(ReturnChosen(KeyCode.Joystick2Button1, PressType.continuous) + KeyCode.Joystick2Button1.ToString());
        Debug.Log(ReturnChosen(KeyCode.Joystick2Button2, PressType.continuous) + KeyCode.Joystick2Button2.ToString());
        Debug.Log(ReturnChosen(KeyCode.Joystick2Button3, PressType.continuous) + KeyCode.Joystick2Button3.ToString());
        Debug.Log(ReturnChosen(KeyCode.Joystick2Button7, PressType.continuous) + KeyCode.Joystick2Button7.ToString());
        Debug.Log(ReturnChosen(KeyCode.Joystick2Button9, PressType.continuous) + KeyCode.Joystick2Button9.ToString());
        Debug.Log((Input.GetAxisRaw("2Axis7") == 1) + "Right");
        Debug.Log((Input.GetAxisRaw("2Axis7") == -1) + "Left");
        Debug.Log((Input.GetAxisRaw("2Axis8") == 1) + "Up");
        Debug.Log((Input.GetAxisRaw("2Axis8") == -1) + "Down");
    }

    private bool ReturnChosen(KeyCode keyCode, PressType pressType)
    {
        switch (pressType)
        {
            case PressType.continuous:
                return Input.GetKey(keyCode);
            case PressType.down:
                return Input.GetKeyDown(keyCode);
            case PressType.release:
                return Input.GetKeyUp(keyCode);
            default:
                return false;
        }
    }
}
