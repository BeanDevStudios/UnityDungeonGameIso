using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject credits;    //Displays credits
    public GameObject start;      //Starts the game
    public GameObject startMenu;  //Displays the start screen

    void Start(){}
    void Update(){}

    //Starts the game when Start Button is pressed
    public void startGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    //Closes the game when Exit Button is pressed
    public void endGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    //Opens the Credit screen when the Credits Button is pressed
    public void openCredits()
    {
        credits.SetActive(true);
        startMenu.SetActive(false);
    }

    //Returns from the Credit screen to the Start Menu Screen
    public void returnToTitle()
    {
        credits.SetActive(false);
        startMenu.SetActive(true);
    }
}
