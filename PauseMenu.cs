using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Must use Unity's SceneManagement library for some functions
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //Boolean to Check if game is paused
    public static bool gameIsPaused = false;

    //A public gameObject that points to the Pause Menu User Interface, which is originally disabled in the scene
    public GameObject PauseMenuUI;
    void Update()
    {
        //If input key escape is pressed (can be switched with any KeyCode for the games purposes)
        //Check whether the game should be paused or continued
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if the game is currently paused, call the resume function
            if (gameIsPaused)
            {
                Resume();
            }
            //If the game is not puased, call the Pause function, which pauses the game
            else
            {
                Pause();
            }
        }
    }

    //Resume function for resuming game if paused
    public void Resume()
        {
            //Deactivate the Pause Menu User Interface, as it should not be a part of the scene
            PauseMenuUI.SetActive(false);
            //Use Unity's Time.timeScale feature, which allows you to change the speed of the game. Part of Unity's
            //library, not C#. Setting Time.timeScale to 1f makes the game speed normal. Must be 1f as timeScale is a 
            //float
            Time.timeScale = 1f;
            //Since the game is continued, set the variable tp False
            gameIsPaused = false;
        }

    //Function to pause game
    void Pause()
    {
        //Enable the Pause Menu User Interface
        PauseMenuUI.SetActive(true);
        //Set Time.timeScale to 0f, as the game's time should not be moving at all. A timescale of 0f achieves that
        Time.timeScale = 0f;
        //The game is paused, so set the variable to True
        gameIsPaused = true;
    }

    //A function to restart the current level, not needed.
    //A button must be included in the PauseMenu UI and it should be linked to this public function for it to be fully
   //functional
    public void Restart()
    {
        //Use Unity's SceneManagement library to load the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Must call Resume, as you can only restart the game when the PauseMenu UI is active
        //PauseMenu UI should only be active when game is paused (Time.timeScale = 0f)
        Resume();
    }

    //Not a mandatory function
    //Used to quit game
    //A button must be included in the PauseMenu UI and it should be linked to this public function for it to be fully
    //functional
    public void Quit()
    {
        //Use the SceneManagement library to Load the mainMenu scene. In this case it is 0, but should be changed
        //to whatever the main Menu scene is indexed in the game.
        //Alteratevely, comment out line 79 and instead use line 80. This can be used if for the game's
        //purposes the application should be terminated instead of going back to the main menu scene.
        //Again, the resume function must be called if you choose like 79 instead of 80
        SceneManager.LoadScene(0);
        //Application.Quit()
        Resume();
    }
}
