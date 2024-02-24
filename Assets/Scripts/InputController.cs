using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("---------- Movement Imputs ----------\n")]
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode specialAttackKey = KeyCode.Mouse1;
    public KeyCode runKey = KeyCode.LeftShift;

    public bool isAttacking = false;
    public bool isSpecialttacking = false;
    public bool isRunning = false;

    public float xAxis, zAxis;
    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(attackKey)) isAttacking = true; else isAttacking = false;
        if (Input.GetKeyDown(specialAttackKey)) isSpecialttacking = true; else isSpecialttacking = false;
        if (Input.GetKey(runKey)) isRunning = true; else isRunning = false;
    }
}