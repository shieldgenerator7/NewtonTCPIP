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
    void Update()
    {
        //Keyboard controls
        float xAxis = Input.GetAxis("Horizontal");
        playerController.moveHorizontally(xAxis);
        float yAxis = Input.GetAxis("Vertical");
        if (yAxis > 0)
        {
            playerController.jump(yAxis);
        }
        if (Input.GetButton("Jump"))
        {
            playerController.jump(1);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            playerController.cancelJump();
        }
    }
}
