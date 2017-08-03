using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    GameObject[] gameOverObjects;
    public Text gameOverText;

    // Use this for initialization
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
        gameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
        
        if (gameOverObjects != null)
        {
            Debug.Log(gameOverObjects.Length.ToString());
            showGameOver();
            hideGameOver();
        }
        else
        {
            Debug.Log(gameOverObjects.Length.ToString());
        }
        
        Time.timeScale = 0;

    }


    //Loads main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    
    public void showGameOver()
    {
        Time.timeScale = 0;
        if (PlayerStats.lives <= 0)
        {
            gameOverText.text = "GameOver";
        }
        else
        {
            gameOverText.text = "Game\nCompleted";
        }
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(true);
        }
    }
    
    public void hideGameOver()
    {
        Time.timeScale = 1;
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }
    }
    
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene("Game");
    }
}
