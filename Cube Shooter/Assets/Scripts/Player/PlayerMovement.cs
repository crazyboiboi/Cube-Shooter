using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

   
    public float normalSpeed = 6f;
    public float sprintSpeed = 10f;

    public float speed;
    Vector3 movement;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    bool isRunning;
    bool isMoving;


    void Awake()
    {
        speed = normalSpeed;
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
    }


    //It involves physics so use FixedUpdate()
    public void FixedUpdate ()
    {
        //Gets Input from user keypress
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Move the player accordingly
        Move(h, v);

        //Return false if the player does not press the any Move button
        isMoving = h != 0 || v != 0;

        //Calling the turning function
        Turning();
	}

    //Function to move the player
    public void Move(float h, float v)
    {
        //So that the player never moves in the Y-axis (upward)
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }


    public bool Running()
    {
        //Set speed to sprint speed IF the player is moving and button pressed is shift
        //We are returning something from this function so it can be used in PlayerStats script
        if (Input.GetButton("Shift") && isMoving)
        {
            speed = sprintSpeed;
            isRunning = true;
        }
        else
        {
            speed = normalSpeed;
            isRunning = false;
        }

        return isRunning;
    }

    //Function for setting walking speed back to normal speed
    //This is also used in PlayerStats script
    public void Walking()
    {
        speed = normalSpeed;
    }


    //Function for turning involving Raycasting
    void Turning ()
    {
        //Detecting mouse movement and adjust a ray accordingly
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        //There are various type of Raycast parameters, check documentation
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newRotation);
        }

    }


}
