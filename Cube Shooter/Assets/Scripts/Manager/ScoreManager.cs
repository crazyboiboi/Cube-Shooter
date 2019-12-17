using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int Score;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();

        Score = 0;
    }

    void Update()
    {
        text.text = "Score : " + Score;
    }




}
