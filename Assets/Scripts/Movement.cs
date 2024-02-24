using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Player
{
    public InputController myInpuntcontroller;
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;
    private Vector3 movePlayer;

    public CharacterController player;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    void Update()
    {
        horizontalMove = myInpuntcontroller.xAxis;
        verticalMove = myInpuntcontroller.zAxis;

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.Move(movePlayer * speed * Time.deltaTime);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
