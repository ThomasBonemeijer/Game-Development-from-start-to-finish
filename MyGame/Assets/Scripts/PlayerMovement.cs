using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;
    public float runSpeed = 50f;
    float horizontalMove = 0f;
    bool isJumping;
    bool isWalking;
    bool jump = false;
    // Update is called once per frame
    void Update()
    {

        if (joystick.Horizontal >= .2f) {
            horizontalMove = runSpeed;
            GetComponent<PlayerHandler>().firstTimePlaying = false;
        } else if (joystick.Horizontal <= -.2f) {
            horizontalMove = -runSpeed;
            GetComponent<PlayerHandler>().firstTimePlaying = false;
        } else {
            horizontalMove = 0;
        }

        if (isJumping == false) {
            if (horizontalMove != 0 && isWalking == false) {
                FindObjectOfType<AudioManager>().Play("PlayerWalk");
                isWalking = true;
            } else if (horizontalMove == 0 && isWalking == true) {
                FindObjectOfType<AudioManager>().Stop("PlayerWalk");
                isWalking = false;
            }
        } else {
            FindObjectOfType<AudioManager>().Stop("PlayerWalk");
            isWalking = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void CharacterJump() {
        if (isJumping == false) {
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
        jump = true;
        isJumping = true;
        animator.SetBool("IsJumping", true);
    }

    public void OnLanding() {
        isJumping = false;
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() {
        // Move Character (Move, Crouch, Jump)
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
