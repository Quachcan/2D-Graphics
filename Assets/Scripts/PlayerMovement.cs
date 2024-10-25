using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    public float moveSpeed = 3f;
    bool isFacingRight = false;
    public float jumpPower = 5f;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        TurnSrpite();

        if (Input.GetButtonDown("Vertical") && isGrounded)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded); 
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void TurnSrpite()
    {
        if(isFacingRight && horizontalInput <0f || !isFacingRight && horizontalInput > 0f)
        {
            if (horizontalInput > 0f) // Di chuyển sang phải
            {
                transform.right = Vector3.right; // Hướng mặt nhân vật sang phải
                isFacingRight = true;
            }
            else if (horizontalInput < 0f) // Di chuyển sang trái
            {
                transform.right = Vector3.left; // Hướng mặt nhân vật sang trái
                isFacingRight = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}
