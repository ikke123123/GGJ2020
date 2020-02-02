using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playAgainUI;
    public GameObject player1;
    public GameObject player2;
    public Movement Player1Check;
    public Movement Player2Check;

    private void Start() 
    {
        Resume();
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    public void PlayGame(){
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
        //SceneManager.LoadScene("Game");
        Debug.Log("PlayGame");
    }
   // public void PlayGameFirst(){
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
    //    SceneManager.LoadScene("Controls");
    //}
     //public void ShowControls(){
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
       // SceneManager.LoadScene("ControlsShowOnly");
    //}

    public void GoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("You quited");
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || InputManager.GetEither(InputType.options,PressType.down))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
            //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
        if (GameIsPaused)
        {
            if (InputManager.GetEither(InputType.x, PressType.down))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
                Resume();
            }

            if (InputManager.GetEither(InputType.circle, PressType.down))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
                GoMainMenu();
            }
        }
        //Seizure check for ending game
        if (Player1Check.seizure == true && Player2Check.seizure == true)
        {
            playAgainUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            if (InputManager.GetEither(InputType.x, PressType.down))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI Click");
                GoMainMenu();
            }
        }
    }
    public void Resume(){
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
