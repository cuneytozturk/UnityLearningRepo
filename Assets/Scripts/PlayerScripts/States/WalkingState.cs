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
        if (Ctx.IsRunPressed)
        {
            SwitchState(Factory.Running());
        }
        else if (!Ctx.IsMovementPressed) {
        SwitchState(Factory.Idle());
        }
    }

    public override void Enter()
    {
    
        Ctx.Animator.SetBool(Ctx.IsWalkingHash, true);
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
        ProcessMove();
    }

    public void ProcessMove()
    {

        //Ctx.currentMovement.x =  Ctx.Speed * Time.deltaTime;
        //Ctx.currentMovement.z =  Ctx.Speed * Time.deltaTime;

        //Ctx.currentMovement = Ctx.MoveDirection * Ctx.Speed * Time.deltaTime;

    }
}
