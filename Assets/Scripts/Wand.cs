using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    //Wand rotation variables
    public Transform body;
    

    //Variable for Raycast
    public Camera cam;


    //Variables for firing
    public float shootTimer;
    public float shootTimerMax;
    bool canShoot;


    //Variables for reload system
    public int currentAmmo;
    public int maxAmmo;
    public float reloadTimer = 2f;
    public float reloadTimerMax;
    bool isReloading;    

    
    
    void Start()
    {
        canShoot = true;
        isReloading = false;
        currentAmmo = maxAmmo;
    }

    
    
    // Update is called once per frame
    void Update()
    {
        MoveWithPlayer();
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0 && canShoot == true)
        {
            Fire();
            currentAmmo--;
            canShoot = false;
        }

        //Timer between shots
        if (canShoot == false)
        {
            shootTimer = shootTimer + Time.deltaTime;

            if (shootTimer > shootTimerMax)
            {
                canShoot = true;
                shootTimer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo == 0)
        {
            isReloading = true;
        }

        
        if (isReloading == true)
        {
            Reload();
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


    public void Reload()
    {
        reloadTimer = reloadTimer + Time.deltaTime;

            if (reloadTimer > reloadTimerMax)
            {
                currentAmmo = maxAmmo;
                isReloading = false;
                reloadTimer = 0;
            }       
    }


    void MoveWithPlayer()
    {
        transform.rotation = body.rotation;
    }
}
