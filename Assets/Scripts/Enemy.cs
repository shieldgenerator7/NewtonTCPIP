using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed = 3;//how fast he moves

    protected Vector3 startPos;
    protected Rigidbody rb;
    protected GameObject player;

    protected virtual void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckpointChecker.respawnPlayer(collision.gameObject);
            transform.position = startPos;
            onCollisionExtra();
        }
    }

    protected virtual void onCollisionExtra()
    {

    }
}
