using UnityEngine;

internal class IdleState : PlayerBaseState
{

    private Vector3 moveDirection = Vector3.zero;

    public IdleState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory) : base(currentContext, factory)
    {
    }

    public override void CheckSwitchState()
    {
        if (_ctx.IsMovementPressed && _ctx.IsRunPressed)
        {
            SwitchState(_factory.Walking());
        }else if(_ctx.IsMovementPressed)
        {
            SwitchState(_factory.Running());
        }
    }

    public override void Enter()
    {
        _ctx.Animator.SetBool(_ctx.IsWalkingHash, false);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, false);

    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        moveDirection.x = _ctx.MovementInput.x;
        moveDirection.z = _ctx.MovementInput.y;
        _ctx.IsMovementPressed = moveDirection.x != 0 || moveDirection.z != 0;
        CheckSwitchState();
    }
}