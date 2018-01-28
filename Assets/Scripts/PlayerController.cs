using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7.0f;
    public bool facingRight = true;

    private Rigidbody rb;
    private JumpAbility ja;
    private SnailController ridingSnail = null;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ja = GetComponent<JumpAbility>();
    }

    public void jump(float amount)
    {
        if (ridingSnail == null)
        {
            ja.jump(amount);
        }
        else
        {
            ridingSnail.jump(amount);
        }
    }

    public void cancelJump()
    {
        if (ridingSnail == null)
        {
            ja.cancelJump();
        }
        else
        {
            ridingSnail.cancelJump();
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
        if (ridingSnail == null)
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = ridingSnail.moveHorizontally(direction);
        }
        Flip(direction);
    }

    public void Flip(float dir)
    {
        if (dir != 0)
        {
            if (dir < 0 && facingRight || dir > 0 && !facingRight)
            {
                Flip(dir > 0);
            }
        }
    }

    public void Flip(bool right)
    {
        facingRight = right;
        float r = 1;
        if (!right)
        {
            r = -1;
        }
        Vector3 cs = transform.localScale;
        transform.localScale = new Vector3(Mathf.Abs(cs.x) * r, cs.y, cs.z);
    }

    /// <summary>
    /// Resets the player's position after he fails
    /// </summary>
    public void respawn()
    {
        CheckpointChecker.respawnPlayer(gameObject);
    }

    public void rideSnail(SnailController sc, bool ride)
    {
        if (ride)
        {
            ridingSnail = sc;
        }
        else
        {
            ridingSnail = null;
        }
    }
}
