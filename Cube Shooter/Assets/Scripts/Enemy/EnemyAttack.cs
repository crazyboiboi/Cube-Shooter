using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    PlayerStats playerHealth;
    GameObject player;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerStats>();
        enemyHealth = GetComponent<EnemyHealth>();

    }


    //Checks for the player is in the range of the collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        //Increasing the variable timer by 1 every 1 second 
        timer += Time.deltaTime;

        //Allow the enemy to attack IF timer exceeds the attack cooldown timer AND if collider detects player AND
        //the enemy's health is greater than 0 (not dead)
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
        
        //This down here is used for debugging purpose
        if (playerHealth.currentHealth <= 0)
        {
            Debug.Log("Player dead");
        }

        
    }


    //Attack function
    void Attack()
    {
        //Reset the attack timer
        timer = 0f;

        //Cause the player's health to lose by how much the damage is
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }


}
