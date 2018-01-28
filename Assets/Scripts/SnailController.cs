﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : MonoBehaviour
{

    public float moveSpeed = 3.0f;
    public int maxHealth = 10;//how many hits it can take
    public GameObject playerHoldPoint;//the GameObject that knows where to hold the player at

    [SerializeField]
    private int health;//current health

    public bool playerRiding = false;
    private bool facingRight = true;

    private PlayerController pc;
    private Rigidbody pcrb;
    private JumpAbility ja;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pcrb = pc.GetComponent<Rigidbody>();
        ja = GetComponent<JumpAbility>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pc.gameObject)
        {
            pc.rideSnail(this, true);
            playerRiding = true;
            pc.gameObject.transform.position = playerHoldPoint.transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (playerRiding)
        {
            pcrb.velocity = rb.velocity;
        }
    }

    public Vector3 jump(float amount)
    {
        ja.jump(amount);
        if (ja.jumpCount == ja.maxJumpCount)
        {
            pc.rideSnail(null, false);
            playerRiding = false;
            pc.transform.position = playerHoldPoint.transform.position + Vector3.up * 2;
            ja.cancelJump();
        }
        return rb.velocity;
    }

    public void cancelJump()
    {
        ja.cancelJump();
    }

    public Vector3 moveHorizontally(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        return rb.velocity;
    }

    
}
