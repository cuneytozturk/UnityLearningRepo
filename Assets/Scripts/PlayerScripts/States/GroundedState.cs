using UnityEngine;

internal class GroundedState : PlayerBaseState
{
    private float groundedGravity = -0.5f;
    public GroundedState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory) : base(currentContext, factory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void InitializeSubState()
    {
        if(!Ctx.IsMovementPressed && !Ctx.IsRunPressed) { SetSubState(Factory.Idle()); }
        else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed) { SetSubState(Factory.Walking()); }
        else { SetSubState(Factory.Running()); }

    }

    public override void Perform()
    {
        applyGravity();
        CheckSwitchState();

    }

    public void applyGravity()
    {
        Ctx.AppliedMovementY = groundedGravity;
        
    }

    public override void CheckSwitchState()
    {
        if (Ctx.IsJumpPressed) {
            SwitchState(Factory.Jumping()); }
    }
}