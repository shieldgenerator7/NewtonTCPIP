using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed = 3;//how fast he moves

    private float stunDuration;//if its stunned, how long for
    private float lastStunTime;//the last time it was stunned

    public bool dead = false;

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
        if (collision.gameObject.CompareTag("Player") && !dead)
        {
            CheckpointChecker.respawnPlayer(collision.gameObject);
            transform.position = startPos;
            onCollisionExtra();
        }
        otherCollisionExtra(collision);
    }

    protected virtual void onCollisionExtra()
    {

    }

    protected virtual void otherCollisionExtra(Collision coll)
    {

    }

    public void stun(float duration)
    {
        stunDuration = duration;
        lastStunTime = Time.time;
    }

    public bool isStunned()
    {
        return Time.time < stunDuration + lastStunTime;
    }
}
