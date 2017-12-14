using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public string Levels;

    public string MainMenu;

    public bool IsPaused;

    public GameObject CanvasforPauseMenu; // to show the image that we created to hide the game

	
	// Update is called once per frame
	void Update () {

        if(IsPaused)
        {
            CanvasforPauseMenu.SetActive(true);
            Time.timeScale = 0f;   // if paused the same should stop rather than moving
        }
        else
        {
            CanvasforPauseMenu.SetActive(false);
            Time.timeScale = 1f;  // reset the game to normal
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused; //to pause if unpause and vice versa
        }
		
	}

    public void Resume()
    {
        IsPaused = false; //to unpause by resume
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(Levels);
    }

    public void Quit()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
