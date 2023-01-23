using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateMachine _ctx;
    protected PlayerStateMachineFactory _factory;
    protected PlayerBaseState(PlayerStateMachine currentContext, PlayerStateMachineFactory factory)
    {
        this._ctx = currentContext;
        this._factory = factory;
    }

    public abstract void Enter();
     public abstract void Perform();

    public abstract void Exit();

    public void SwitchState(PlayerBaseState newState) {
        Exit();
        newState.Enter();
        _ctx.ActiveState= newState;
    }

    public abstract void CheckSwitchState();


}
