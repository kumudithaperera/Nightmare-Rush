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
        rigidBody.velocity = new Vector3(joystick.Horizontal * 5f, rigidBody.velocity.y, joystick.Vertical * 5f);

        if (!jump && joyButton.pressed)
        {
            jump = true;
            rigidBody.velocity += Vector3.up * 2f;
        }

        if(jump && !joyButton.pressed)
        {
            jump = false;
        }
    }

}
