using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    public float moveSpeed;
    public float jumpHeight;
    public CharacterController controller;

    //Gravity variables
    Vector3 velocity;
    public float gravity = -5f;

    //Ground Check variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Move();


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpHeight;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }


    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;  //Allows player to move in all directions
        controller.Move(move * moveSpeed * Time.deltaTime);

    }


    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  //Checks to see if collision is detected

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;   //Removes excess velocity
        }
    }
}
