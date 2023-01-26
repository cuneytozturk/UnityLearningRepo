using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class RunningState : PlayerBaseState
{
    public RunningState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory) : base(currentContext, factory)
    {
    }

    public override void CheckSwitchState()
    {
        
        if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed) {
            SwitchState(Factory.Idle());
        }
        else if (!Ctx.IsRunPressed)
        {
            SwitchState(Factory.Walking());
        }
       
    }

    public override void Enter()
    {
        Ctx.Animator.SetBool(Ctx.IsWalkingHash, false);
        Ctx.Animator.SetBool(Ctx.IsRunningHash, true);

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

    public void ProcessMove() {
        //Ctx.Controller.Move(Ctx.MoveDirection * Ctx.RunSpeedMultiplier * Ctx.Speed * Time.deltaTime);
        //Ctx.currentMovement = Ctx.MoveDirection * Ctx.Speed * Time.deltaTime;
        //Ctx.currentMovement.x = Ctx.RunSpeedMultiplier * Ctx.Speed * Time.deltaTime;
       //Ctx.currentMovement.z = Ctx.RunSpeedMultiplier * Ctx.Speed * Time.deltaTime;
    }
}
