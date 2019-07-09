using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;
    public Button jumpButton;
    public float runSpeed = 50f;
    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // horizontalMove = joystick.Horizontal * runSpeed;

        if (joystick.Horizontal >= .2f) {
            horizontalMove = runSpeed;
        } else if (joystick.Horizontal <= -.2f) {
            horizontalMove = -runSpeed;
        } else {
            horizontalMove = 0;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // if (Input.GetButtonDown("Jump")) {
        //     jump = true;
        // }
        // jumpButton.onClick.AddListener(CharacterJump);
    }

    public void CharacterJump() {
        jump = true;
        animator.SetBool("IsJumping", true);
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() {
        // Move Character (Move, Crouch, Jump)
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
