using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Joystick joystick;
    public float runSpeed = 50f;
    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // horizontalMove = joystick.Horizontal * runSpeed;

        if (joystick.Horizontal >= .2f) {
            horizontalMove = runSpeed;
        } else if (joystick.Horizontal <= -.2f) {
            horizontalMove = -runSpeed;
        } else {
            horizontalMove = 0;
        }

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    void FixedUpdate() {
        // Move Character (Move, Crouch, Jump)
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
