using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7.0f;
	public bool facingRight = true;

    private Rigidbody rb;
    private JumpAbility ja;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ja = GetComponent<JumpAbility>();
    }

    public void jump(float amount)
    {
        ja.jump(amount);
    }

    public void cancelJump()
    {
        ja.cancelJump();
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
}
