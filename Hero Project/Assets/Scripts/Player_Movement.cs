using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    private bool isUsingMouse;
    public float acceleration, speed, rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isUsingMouse = true;
        speed = 0;
        acceleration = 10;
        rotationSpeed = 90;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            isUsingMouse = !isUsingMouse;
            TextEditor.isUsingMouse = isUsingMouse;
        }


        //Rotation
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.D))
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);;


        //Movement Using Mouse
        if(isUsingMouse)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouse;
        }
        
        //Movement Using Keyboard
        else
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                speed += acceleration * Time.deltaTime;
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                speed -= acceleration * Time.deltaTime;

            float ySpeed = speed * Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad + Mathf.PI / 2);
            float xSpeed = speed * Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad + Mathf.PI / 2);

            //transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }


}
