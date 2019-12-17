using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public int damage = 10;
    public float range = 50f;
    public float timeBetweenShots = 0.2f;

    float timer;
    int shootableMask;
    Ray shootRay = new Ray();
    LineRenderer gunLine;
    AudioSource laserSound;
    float effectsDisplayTime = 0.2f;




    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();
        laserSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        //Increaser timer by 1 every 1 second
        timer += Time.deltaTime;

        //Checks IF left mouse button is pressed, timer exceeds cooldown timer for shooting, the game is not paused and not over
        if (Input.GetButton("Fire1") && timer >= timeBetweenShots && Time.timeScale != 0 && !GameOverManager.isGameOver)
        {
            Shoot();
        }

        //Disable the shooting line after a certain time from shooting
        if (timer >= timeBetweenShots * effectsDisplayTime)
        {
            DisableEffects();
        }

    }

    void DisableEffects()
    {
        gunLine.enabled = false;
    }



    void Shoot()
    {
        //Resets the timer after shooting 
        timer = 0f;
        RaycastHit shootHit;

        laserSound.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        //Ray starts from the gun barrel at a forward direction
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        //Detects the position where the Ray touches
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //If there is an EnemyHealth script attached to it, then call TakeDamage()
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, shootHit.point);
            }
            //Set the position of the Ray at where it hits
            gunLine.SetPosition(1, shootHit.point);            
        }
        else
        {
            //If didn't hit anything then extend the Ray until maximum and that is the final position
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }



    }




}
