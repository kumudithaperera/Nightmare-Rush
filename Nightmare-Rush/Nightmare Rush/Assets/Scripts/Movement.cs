using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected Joystick joystick;
    protected joyButton joyButton;

    protected bool jump;
    private bool isGrounded;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<joyButton>();
    }

    
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(joystick.Horizontal * 4f, rigidBody.velocity.y, joystick.Vertical * 4f);

        if(isGrounded == false) 
        {
            
            if (joyButton.pressed)
            {
                jump = true;
                rigidBody.velocity += Vector3.up * 3f;
            }


        }

        if (isGrounded == true) 
        {
            if (!joyButton.pressed)
            {
                jump = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }


}
