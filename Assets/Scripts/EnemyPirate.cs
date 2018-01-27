using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirate : Enemy {

    public float moveDistance = 5;//how far from the center he can move
    public float moveSpeed = 3;//how fast he moves

    private Vector3 startPos;
    private float moveDirection = 1;//which direction he is moving

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            moveDirection *= -1;
        }
        rb.velocity = new Vector3(moveDirection * moveSpeed, rb.velocity.y);
	}

    
}
