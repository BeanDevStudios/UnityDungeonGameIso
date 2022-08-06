using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]public GameObject pauseMenuUI; //Gets the Game Object that holds our pasue menu
    [SerializeField]private bool isPaused; //Checks to see if game is paused


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            openPauseMenu();
            isPaused = true;
        }
    }

    //Opens the pause menu
    public void openPauseMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    
    }

    //Closes the pause menu
    public void closePauseMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void returnToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
