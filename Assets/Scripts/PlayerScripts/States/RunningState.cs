using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class RunningState : PlayerBaseState
{

    private float runMultiplier = 3.0f;

    public RunningState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory) : base(currentContext, factory)
    {
    }

    public override void CheckSwitchState()
    {
        if (!_ctx.IsRunPressed)
        {
            SwitchState(_factory.Walking());
        }
    }

    public override void Enter()
    {
        _ctx.Animator.SetBool(_ctx.IsWalkingHash, false);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, true);

    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        CheckSwitchState();
        ProcessMove();
    }

    public void ProcessMove() {
        _ctx.IsMovementPressed = _ctx.AppliedMovementX != 0 || _ctx.AppliedMovementZ != 0;
        _ctx.AppliedMovementX = _ctx.MovementInput.x * runMultiplier;
        _ctx.AppliedMovementZ = _ctx.MovementInput.y * runMultiplier;

        _ctx.Controller.Move(_ctx.MoveDirection * _ctx.Speed * Time.deltaTime);



        if (_ctx.PlayerVelocityY < 0)
        {
            _ctx.PlayerVelocityY = -2f;
        }

        _ctx.PlayerVelocityY += _ctx.Gravity * Time.deltaTime;
        _ctx.Controller.Move(_ctx.PlayerVelocity * Time.deltaTime);
    }
}
