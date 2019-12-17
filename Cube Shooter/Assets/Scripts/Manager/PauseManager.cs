using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public PlayerStats playerHealth;

    void Awake()
    {
        playerHealth = GetComponent<PlayerStats>();
    }

    void Update()
    {
        //Checks for key pressed is Escape and the game is not over
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverManager.isGameOver)
        {            
            //IF the game is not paused, then pause it
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
