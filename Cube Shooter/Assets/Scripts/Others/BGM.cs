using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour {

    void Awake()
    {
        //Destroy the object if the next scene spawns same object
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length >1 )
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        /*if (SceneManager.GetActiveScene().name == "Level01")
        {
            Destroy(this.gameObject);
        }*/
    }
}
