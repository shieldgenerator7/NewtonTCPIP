﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 7.0f;
    public float jumpSpeed = 5.0f;
    public float jumpDuration = 0.1f;//how long the jump can be 
    public int maxJumpCount = 2;//how many jumps per ground he can do (2 = "double jump")
	public bool facingRight;

    private float lastGroundTime;//the last time he was on the ground
    [SerializeField]
    private int jumpCount = 0;
    private bool jumpStarted = false;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
		facingRight = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].point.y <= transform.position.y)
        {
            lastGroundTime = Time.time;
            jumpCount = 0;
            jumpStarted = false;
        }
    }

    /// <summary>
    /// Move horizontally.
    /// less than 0 = move left
    /// greater than 0 = move right
    /// </summary>
    /// <param name="direction"></param>
    public void moveHorizontally(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
    /// <summary>
    /// Makes the character jump
    /// </summary>
    /// <param name="jumpAmount"></param>
    public void jump(float jumpAmount)
    {
        if (!jumpStarted)
        {
            jumpStarted = true;
            jumpCount++;
            lastGroundTime = Time.time;
        }
        if (Time.time <= lastGroundTime + jumpDuration) {
            jumpAmount = Mathf.Max(0, jumpAmount);
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount * jumpSpeed);
        }
    }
    public void cancelJump()
    {
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            if (jumpCount < maxJumpCount)
            {
                jumpStarted = false;
            }
        }
    }

	public void Flip()
	{
		
	}

    /// <summary>
    /// Resets the player's position after he fails
    /// </summary>
    public void respawn()
    {
        CheckpointChecker.respawnPlayer(gameObject);
    }
}
