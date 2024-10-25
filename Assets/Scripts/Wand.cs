using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    //Wand rotation variables
    public Transform body;
    

    //Variable for Raycast
    public Camera cam;


    //Variables for timer
    public float timer;
    public float timerMax;
    bool canShoot;

    
    
    void Start()
    {
        canShoot = true;
    }

    
    
    // Update is called once per frame
    void Update()
    {
        MoveWithPlayer();
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
            canShoot = false;
        }

        //Timer between shots
        if (canShoot == false)
        {
            timer = timer + Time.deltaTime;

            if (timer > timerMax)
            {
                canShoot = true;
                timer = 0;
            }
        }
    }


    public void Fire()
    {
        //Detects if ray has hit anything
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            print("I am looking at: " + hit.transform.name);
        }
        else
        {
            print("I am looking at nothing!");
        }
    }


    void MoveWithPlayer()
    {
        transform.rotation = body.rotation;
    }
}
