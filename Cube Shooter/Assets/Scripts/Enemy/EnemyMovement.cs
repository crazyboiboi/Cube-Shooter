using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    PlayerStats playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerStats>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
        {
            //Calling the AINavigation componenet to follow the player
            nav.SetDestination(player.position);
        }
        else
        {
            //Disable the component if player is dead
            nav.enabled = false;
        }          
        
    }

}
