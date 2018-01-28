using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirate : Enemy
{

    public float moveDistance = 5;//how far from the center he can move

    private float moveDirection = 1;//which direction he is moving

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStunned())
        {
            if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
            {
                if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance + 2)
                {
                    startPos = transform.position;
                }
                moveDirection *= -1;
            }
            rb.velocity = new Vector3(moveDirection * moveSpeed, rb.velocity.y);
            if (rb.velocity.sqrMagnitude < 0.01f)
            {
                moveDirection *= -1;
            }
        }
    }

    protected override void otherCollisionExtra(Collision coll)
    {
        if (coll.contacts[0].point.y <= transform.position.y)
        {
            startPos = transform.position;
        }
    }
}
