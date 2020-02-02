using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("David");
    }
    public void GoControls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You quited");
    }
    private void Update()
    {
        if (InputManager.GetEither(InputType.triangle, PressType.down))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
            GoControls();
        }
        else if (InputManager.GetEither(InputType.x, PressType.down))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
            PlayGame();
        }
        else if (InputManager.GetEither(InputType.circle, PressType.down))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
            QuitGame();
        }
        if (InputManager.GetEither(InputType.square, PressType.down))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
            GoMainMenu();
        }
    }
}
