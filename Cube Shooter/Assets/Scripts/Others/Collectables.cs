using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    public float degreesPerSecond = 30f;
    public float amplitude = 0.5f;
    public float frequency = 1.0f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();


    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        float rotation = Time.deltaTime * degreesPerSecond;

        transform.Rotate(new Vector3(0f, rotation, 0f), Space.World);
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }



}
