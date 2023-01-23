using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedState : EnemyBaseState
{
    public DetectedState(EnemyStateMachine currentContext, EnemyStateMachineFactory enemyStateFactory) : base(currentContext, enemyStateFactory)
    {
    }

    public override void CheckSwitchState()
    {
        throw new System.NotImplementedException();
    }

    public override void Enter()
    {
        Debug.Log("player detected debug hello");
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Perform()
    {
        throw new System.NotImplementedException();
    }
}
