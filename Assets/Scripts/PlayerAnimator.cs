using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private InputController _myInputController;
    [SerializeField] private PlayerAttack _myPlayerAttack;

    [SerializeField] private Animator _myAnimator;

    [SerializeField] private string _isRunningName = "isRunning";
    [SerializeField] private string _isWalkingName = "isWalking";
    [SerializeField] private string _isAttackingName = "isAttacking";

    void Start()
    {

    }

    void Update()
    {
        _myAnimator.SetBool(_isRunningName, _myInputController.isRunning);
        _myAnimator.SetBool(_isWalkingName, _myInputController.isWalking);

        _myAnimator.SetBool(_isAttackingName, _myInputController.isAttacking);
    }
}
