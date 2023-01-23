using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : PlayerBaseState
{
    public WalkingState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory) : base(currentContext, factory)
    {
    }

    public override void CheckSwitchState()
    {
        if (_ctx.IsRunPressed)
        {
            SwitchState(_factory.Running());
        }
        else if (!_ctx.IsMovementPressed) {
        SwitchState(_factory.Idle());
        }
    }

    public override void Enter()
    {
    
        _ctx.Animator.SetBool(_ctx.IsWalkingHash, true);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, false);
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        CheckSwitchState();
        ProcessMove();
    }

    public void ProcessMove()
    {
        _ctx.IsMovementPressed = _ctx.AppliedMovementX != 0 || _ctx.AppliedMovementZ != 0;
        _ctx.AppliedMovementX = _ctx.MovementInput.x;
        _ctx.AppliedMovementZ = _ctx.MovementInput.y;

        _ctx.Controller.Move(_ctx.MoveDirection * _ctx.Speed * Time.deltaTime);


        if (_ctx.PlayerVelocityY < 0)
        {
            _ctx.PlayerVelocityY = -2f;
        }

        _ctx.PlayerVelocityY += _ctx.Gravity * Time.deltaTime;
        _ctx.Controller.Move(_ctx.PlayerVelocity * Time.deltaTime);
    }
}
