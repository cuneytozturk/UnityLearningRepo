using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    private PlayerStateMachine _ctx;
    private PlayerStateMachineFactory _factory;
    private PlayerBaseState _currentSuperState;
    private PlayerBaseState _currentSubState;
    private bool _isRootState = false;
   

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
        if (_isRootState)
        {
            _ctx.ActiveState = newState;
        }else if(_currentSuperState!= null) {
            SetSubState(newState);
        }
    }

    public abstract void CheckSwitchState();

    public abstract void InitializeSubState();

    public void PerformStates() {
        Perform();
        if (_currentSubState != null) {
        _currentSubState.PerformStates();
        }
    }  

    protected void SetSuperState(PlayerBaseState newSuperState) {
        _currentSuperState = newSuperState;
    }
    protected void SetSubState(PlayerBaseState newSubState) {
    _currentSubState = newSubState;
    newSubState.SetSuperState(this);
    }

    public PlayerStateMachine Ctx { get { return _ctx; } }
    public PlayerStateMachineFactory Factory { get { return _factory; } }
    public bool IsRootState { get { return _isRootState; } set { _isRootState = value; } }

}
