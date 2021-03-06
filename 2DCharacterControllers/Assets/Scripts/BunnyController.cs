﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {

    public float MaxSpeed = 10f;
    bool FacingRight = true;
    public Rigidbody2D rb2d;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float JumpForce = 700f;

    Animator bunnyAnimator;

    void Start()
    {
        bunnyAnimator = GetComponent<Animator>();
    }

    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        bunnyAnimator.SetBool("Ground", grounded);

        bunnyAnimator.SetFloat("vSpeed", rb2d.velocity.y);

        float move = Input.GetAxis("Horizontal");

        bunnyAnimator.SetFloat("Speed", Mathf.Abs(move));

        //Rigidbody2D.velocity = new Vector2(move * MaxSpeed, Rigidbody2D.velocity.y);

        rb2d.velocity = new Vector2(move * MaxSpeed, rb2d.velocity.y);

        if(move > 0 && !FacingRight)
        {
            Flip();
        }
        else if (move < 0 && FacingRight)
        {
            Flip();
        }
	}

    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            bunnyAnimator.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(0, JumpForce));
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
