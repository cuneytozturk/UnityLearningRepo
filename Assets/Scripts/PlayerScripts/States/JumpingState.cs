using System;
using UnityEngine;
using UnityEngine.InputSystem;

internal class JumpingState : PlayerBaseState
{
    float maxJumpHeight = 3.0f;
    float maxJumpTime = 0.5f;
    float initialJumpVelocity;
    

    public JumpingState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory) : base(currentContext, factory)
    {
        IsRootState= true;
    }

    public override void CheckSwitchState()
    {
        if (Ctx.IsGrounded) {
            SwitchState(Factory.Grounded());
        }
    }

    public override void Enter()
    {
        calculateJumpVariables();
        doJump();
    }

    public override void Exit()
    {
    }

    public override void InitializeSubState()
    {
        if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed) { SetSubState(Factory.Idle()); }
        else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed) { SetSubState(Factory.Walking()); }
        else { SetSubState(Factory.Running()); }
    }

    public override void Perform()
    {
        applyGravity();
        CheckSwitchState();

    }

    private void calculateJumpVariables() {
        float timeToApex = maxJumpTime / 2;
        Ctx.Gravity = (-2 * maxJumpHeight) / MathF.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    private void doJump()
    {
        Ctx.AppliedMovementY = initialJumpVelocity;
    }

    public void applyGravity() {
        Ctx.AppliedMovementY += Ctx.Gravity * Time.deltaTime;
    }

}