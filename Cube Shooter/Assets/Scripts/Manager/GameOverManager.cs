using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public PlayerStats playerHealth;
    public GameObject gameOverUI;
    public static bool isGameOver = false;

    float restartTimer;
    Animator anim;

    void Awake()
    {
        isGameOver = false;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //Plays the fade in fade out animation
        if (playerHealth.currentHealth <= 0 )
        {
            //This is so that the player doesn't accidently pressed on the transparent Retry button
            gameOverUI.SetActive(true);
            isGameOver = true;
            anim.SetTrigger("GameOver");
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Level01");
    }
}
