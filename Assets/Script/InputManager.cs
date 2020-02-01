using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool GetEither(InputType inputType, PressType pressType = PressType.continuous)
    {
        return Get(inputType, PlayerType.Player1, pressType) || Get(inputType, PlayerType.Player2, pressType);
    }

    public static bool Get(InputType inputType, PlayerType playerType, PressType pressType = PressType.continuous)
    {
        if (playerType == PlayerType.Player1)
        {
            switch (inputType)
            {
                case InputType.square:
                    return ReturnChosen(KeyCode.Joystick1Button0, pressType);
                case InputType.x:
                    return ReturnChosen(KeyCode.Joystick1Button1, pressType);
                case InputType.circle:
                    return ReturnChosen(KeyCode.Joystick1Button2, pressType);
                case InputType.triangle:
                    return ReturnChosen(KeyCode.Joystick1Button3, pressType);
                case InputType.reviving:
                    return ReturnChosen(KeyCode.Joystick1Button7, pressType);
                case InputType.options:
                    return ReturnChosen(KeyCode.Joystick1Button9, pressType);
                case InputType.up:
                    return Input.GetAxisRaw("1Axis8") == 1;
                case InputType.down:
                    return Input.GetAxisRaw("1Axis8") == -1;
                case InputType.left:
                    return Input.GetAxisRaw("1Axis7") == -1;
                case InputType.right:
                    return Input.GetAxisRaw("1Axis7") == 1;
                default:
                    return false;
            }
        }
        if (playerType == PlayerType.Player2)
        {
            switch (inputType)
            {
                case InputType.square:
                    return ReturnChosen(KeyCode.Joystick2Button0, pressType);
                case InputType.x:
                    return ReturnChosen(KeyCode.Joystick2Button1, pressType);
                case InputType.circle:
                    return ReturnChosen(KeyCode.Joystick2Button2, pressType);
                case InputType.triangle:
                    return ReturnChosen(KeyCode.Joystick2Button3, pressType);
                case InputType.reviving:
                    return ReturnChosen(KeyCode.Joystick2Button7, pressType);
                case InputType.options:
                    return ReturnChosen(KeyCode.Joystick2Button9, pressType);
                case InputType.up:
                    return Input.GetAxisRaw("2Axis8") == 1;
                case InputType.down:
                    return Input.GetAxisRaw("2Axis8") == -1;
                case InputType.left:
                    return Input.GetAxisRaw("2Axis7") == -1;
                case InputType.right:
                    return Input.GetAxisRaw("2Axis7") == 1;
                default:
                    return false;
            }
        }
        return false;
    }

    private static bool ReturnChosen(KeyCode keyCode, PressType pressType)
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
