using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;

    //Gravity variables
    Vector3 velocity;
    public float gravity = -5f;

    //Ground Check variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  //Checks to see if collision is detected

        if(isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;   //Removes excess velocity

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

         Vector3 move = transform.right * x + transform.forward * z;  //Allows player to move in all directions

        transform.position += move * moveSpeed * Time.deltaTime;

    }
}
