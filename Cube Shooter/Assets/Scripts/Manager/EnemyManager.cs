using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public PlayerStats playerHealth;
    public GameObject[] enemy;
    //public float SpawnTime = 3f;
    public Transform[] spawnPoints;



    //This is fixed time enemy spawning

    /*void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                
    }*/

    //This is varied time enemy spawning
    //Check documentation on coroutines
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (playerHealth.currentHealth > 0)
        {
            int someTime = Random.Range(1, 4);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int enemyType = Random.Range(0, enemy.Length);
            Instantiate(enemy[enemyType], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            yield return new WaitForSeconds(someTime);
        }
    }

}
