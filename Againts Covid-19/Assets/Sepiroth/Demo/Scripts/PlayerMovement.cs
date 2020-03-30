using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 80f;
    float horizontalMove;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        SoundManager.PlaySound("music");
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; 
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            SoundManager.PlaySound("jump");
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        }
        else
        {
            crouch = false; 
        }


        if (Input.touchCount > 0)
        {
                Touch touch = Input.GetTouch(0);

                float direction = touch.position.x > Screen.width / 2 ? 1 : -1;
                horizontalMove = direction * runSpeed;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if ((Input.touchCount > 1))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
            if ((touch.position.y < Screen.width / 8))
            {
                crouch = true;
            }
        }

    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);

    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
