using UnityEngine;

public class Movement : Player
{
    public InputController myInpuntcontroller;
    public float horizontalMove;
    public float verticalMove;
    public float runSpeed;
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

        if (myInpuntcontroller.isRunning)
        {
            player.Move(movePlayer * runSpeed * Time.deltaTime);
        }
        else player.Move(movePlayer * speed * Time.deltaTime);

        LookAt();
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

    void LookAt()
    {
        if (movePlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movePlayer, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Adjust rotation speed as needed
        }
    }

}
