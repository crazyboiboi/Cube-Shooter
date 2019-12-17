using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    //All of these are public so it can assign to the button on click

    public void PlayGame()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;
        PauseManager.GameIsPaused = false;
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void OptionBack()
    {
        SceneManager.LoadScene("StartMenu");
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit game success");
    }
}
