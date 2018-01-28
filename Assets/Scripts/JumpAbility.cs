using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : MonoBehaviour {

    public float jumpSpeed = 5.0f;
    public float jumpDuration = 0.1f;//how long the jump can be 
    public int maxJumpCount = 2;//how many jumps per ground he can do (2 = "double jump")

    private float lastGroundTime;//the last time he was on the ground
    [SerializeField]
    public int jumpCount = 0;
    [SerializeField]
    private bool jumpStarted = false;

    [Range(1.0f, 2.0f)]
    public float stretchSquash = 1.1f;//0=normal, 1/2 = squash, 2 = stretch
    private float stretchSize = 1;
    private float squashSize = 1;
    private Vector3 startSize;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startSize = transform.localScale;
        stretchSize = stretchSquash;
        squashSize = 1 / stretchSquash;
    }

    private void Update()
    {
        float sign = Mathf.Sign(transform.localScale.x);
        transform.localScale = Vector3.MoveTowards(
            transform.localScale,
            new Vector3(sign * startSize.x / stretchSquash, startSize.y * stretchSquash, startSize.z),
            0.25f
            );
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].point.y <= transform.position.y)
        {
            lastGroundTime = Time.time;
            jumpCount = 0;
            jumpStarted = false;
            stretchSquash = 1;
        }
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
            stretchSquash = stretchSize;
        }
        if (Time.time <= lastGroundTime + jumpDuration)
        {
            jumpAmount = Mathf.Max(0, jumpAmount);
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount * jumpSpeed);
        }
        else
        {
            stretchSquash = squashSize;
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
            stretchSquash = squashSize;
        }
    }
}
