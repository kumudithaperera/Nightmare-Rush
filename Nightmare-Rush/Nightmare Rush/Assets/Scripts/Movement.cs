using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected Joystick joystick;
    protected joyButton joyButton;

    protected bool jump;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<joyButton>();
    }

    
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(joystick.Horizontal * 4f, rigidBody.velocity.y, joystick.Vertical * 4f);

        if(!jump && joyButton.pressed)
        {
            jump = true;
            rigidBody.velocity += Vector3.up * 4f;
            if (gameObject.tag == "ground")
            {
                jump = true;
            }
        }

        if(jump && !joyButton.pressed)
        {
            jump = false;
            if (gameObject.tag == "ground")
            {
                jump = false;
            }
        }
    }

    //void OnCollisionEnter(Collider other)
    //{
        
    //}

    //void OnCollisionExit(Collider other)
    //{
        
    //}


}
