using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {

    public float MaxSpeed = 10f;
    bool FacingRight = true;
    public Rigidbody2D rb2d;

	void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");

        //Rigidbody2D.velocity = new Vector2(move * MaxSpeed, Rigidbody2D.velocity.y);

        rb2d.velocity = new Vector2(move * MaxSpeed, rb2d.velocity.y);
	}
}
