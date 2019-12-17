using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public Transform enemy;
    public int startingHealth = 50;    
    public int scoreValue = 10;
    public GameObject[] Drop;
    public int currentHealth;

    bool isDead;
    bool isSinking;
    float sinkSpeed = 2.5f;
    ParticleSystem hitParticles;
    


    void Awake()
    {
        //Initiate enemy health to its starting health
        currentHealth = startingHealth;
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }


    private void Update()
    {
        //Check for IF isSinking is true, if true sinks the enemy down the ground as if disappearing
        if (isSinking)
        {
            //From current position, sinks negatively in upward direction at a specified speed
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    //Function to take damage
    //This is called by the player if the Raycasting detects the enemy object
    //The enemy will then take player damage and the position where it is hit
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        //When enemy dead, do nothing
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;

        //Plays the Particle System at the hit point
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();


        //If health is less than 0 then call Destroy() which kills the enemy
        if (currentHealth <= 0)
        {
            Destroy();
            //Additional code to loop the Particle System
            var hp = hitParticles.main;
            hp.loop = true;
        }
    }

    //Function to kill enemy/destroy them
    void Destroy ()
    {
        //Set the variable isSinking to true so that the enemy can start sinking @Update
        isSinking = true;

        //Set isKinematic to true so that other enemy objects won't bump into the dead enemy when sinking
        GetComponent<Rigidbody>().isKinematic = true;
        isDead = true;

        //Increase player's score value
        ScoreManager.Score += scoreValue;

        //Remove the object completely from the scene after 2 seconds
        //2 seconds to display sinking 'animation'
        Destroy(gameObject, 2f);

        //Here we initialize few variables to allow the enemy to drop Health or Stamina pack after dying
        //We will have a set chance which enemy will drop if the Random generates the number which is
        //Greater or equal to
        int dropChance = 7;
        int chance = Random.Range(0, 10);

        //Chooses either Health or Stamina pack to drop
        int dropIndex = Random.Range(0, Drop.Length);

        //This offset spawns the item drop abit lower because the enemy object is quite tall
        Vector3 offset = new Vector3(0f, -0.8f, 0f);

        if (chance >= dropChance)
        {
            Instantiate(Drop[dropIndex], enemy.position + offset  , enemy.rotation);
        }
    }



}
