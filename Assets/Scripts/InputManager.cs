using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public PlayerController playerController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Keyboard controls
        float xAxis = Input.GetAxis("Horizontal");
        playerController.moveHorizontally(xAxis);
        if (Input.GetButton("Jump"))
        {
            playerController.jump(1);
        }
        //Be sure to cancel the jump when the player stops jumping
        //*This is IMPORTANT*
        else if (Input.GetButtonUp("Jump"))
        {
            playerController.cancelJump();
        }
    }
}
