using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpamula : Enemy {

    public float cooldownDuration = 1.0f;//how long she has to go on cooldown after moving
    public float chaseDuration = 3.0f;//how long she chases the player for
    public float sightRange = 5.0f;//how far she can see the player

    private float lastCooldownTime;//the last time the cooldown started
    private float chaseStartTime;//when she started moving

	// Use this for initialization
	protected override void Start () {
        base.Start();
        chaseStartTime = -chaseDuration * 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isStunned())
        {
            //If she's moving
            if (Time.time <= chaseStartTime + chaseDuration)
            {
                if (true || Physics.Raycast(new Ray(transform.position, Vector3.down), 1))
                {
                    rb.velocity = new Vector3(Mathf.Sign(player.transform.position.x - transform.position.x) * moveSpeed, rb.velocity.y);
                }
            }
            //If her movement is off cooldown
            if (Time.time > lastCooldownTime + cooldownDuration)
            {
                //If player is in range
                if ((player.transform.position - transform.position).sqrMagnitude <= sightRange * sightRange)
                {
                    chaseStartTime = Time.time;
                    //Pre-prepare the cooldown
                    lastCooldownTime = Time.time + chaseDuration + cooldownDuration;
                }
            }
        }
	}

    protected override void onCollisionExtra()
    {
        chaseStartTime = 0;
    }
}
