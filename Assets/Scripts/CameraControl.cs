using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Camera control variables
    public float sensitivity = 100f;
    public Transform body;

    private float xRotation = 0f;


    void Start()
    {
        //Positions the pointer in the centre of the game & turns it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);   //Limits camera movement between 90 and -90 around the x-axis

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);  //Rotates player horizontally
    }
}
