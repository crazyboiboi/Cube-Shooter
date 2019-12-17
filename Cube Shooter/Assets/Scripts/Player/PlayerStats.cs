using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public int MaxHealth= 100;
    public float MaxStamina = 100f;
    public int currentHealth;
    public float currentStamina;
    public Slider healthSlider;
    public Slider staminaSlider;
    public Text healthText;
    public Text staminaText;

    PlayerMovement playerMovement;
    bool isDead;



    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = MaxHealth;
        currentStamina = MaxStamina;
    }


    void Update()
    {
        //Checks IF the function Running() from playerMovement scirpt and currentStamina is more than 0
        if (playerMovement.Running() && currentStamina > 0 )
        {
            //Calls DrainStamina() function
            DrainStamina();
        }
        else
        {
            //Player can only move
            playerMovement.Walking();
        }
        
    }

    //Player take damage function
    //Called from enemyAttack script
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        //Interact with the slider value
        healthSlider.value = currentHealth;
        healthText.text = currentHealth.ToString();

        //Checks player's current health AND haven't die
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        
    }

    //Drain stamina function when sprinting
    void DrainStamina ()
    {
        currentStamina -= 10 * Time.deltaTime ;

        staminaSlider.value = currentStamina;
        staminaText.text = currentStamina.ToString("0");
    }

    void Death ()
    {
        isDead = true;
        playerMovement.enabled = false;
    }

    //Colliding with Health and Stamina pack function
    void OnTriggerEnter(Collider other)
    {
        //Checks for the collided object tag has Health or Stamina 
        if (other.gameObject.CompareTag("Health"))
        {
            //Checks for player health
            //Allow the player to collect the pack regardless and destroy afterwards
            //If 90 and above then set to max Health or Stamina
            //Else add 10 to any one of the stats
            //Update UI slider value as well
            if (currentHealth <= 90)
            {
                Destroy(other.gameObject);
                currentHealth += 10;
                healthSlider.value = currentHealth;
                healthText.text = currentHealth.ToString();
            }
            else
            {
                Destroy(other.gameObject);
                currentHealth = MaxHealth;
                healthSlider.value = currentHealth;
                healthText.text = currentHealth.ToString();
            }

        }

        if (other.gameObject.CompareTag("Stamina"))
        {
            if (currentStamina <= 90)
            {
                Destroy(other.gameObject);
                currentStamina += 10;
                staminaSlider.value = currentStamina;
                staminaText.text = currentStamina.ToString("0");
            }
            else
            {
                Destroy(other.gameObject);
                currentStamina = MaxStamina;
                staminaSlider.value = currentStamina;
                staminaText.text = currentStamina.ToString("0");
            }            
        }
    }

    //Restart game function used in HUDCanvas object referencing to GameOverManager
    public void RestartGame()
    {
        SceneManager.LoadScene("Level01");
    }
}
