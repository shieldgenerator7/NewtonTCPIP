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
