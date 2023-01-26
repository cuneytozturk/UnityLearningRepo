using UnityEngine;

internal class IdleState : PlayerBaseState
{

    private Vector3 moveDirection = Vector3.zero;

    public IdleState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory) : base(currentContext, factory)
    {
    }

    public override void CheckSwitchState()
    {
        if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SwitchState(Factory.Running());
        }else if(Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Walking());
        }
    }

    public override void Enter()
    {
        Ctx.Animator.SetBool(Ctx.IsWalkingHash, false);
        Ctx.Animator.SetBool(Ctx.IsRunningHash, false);

    }

    public override void Exit()
    {
    }

    public override void InitializeSubState()
    {
    }

    public override void Perform()
    {
        
        CheckSwitchState();
    }
}