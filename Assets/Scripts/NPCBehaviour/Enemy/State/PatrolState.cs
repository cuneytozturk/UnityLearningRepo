using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyBaseState
{
    private int waypointIndex;

    public PatrolState(EnemyStateMachine context, EnemyStateMachineFactory enemyStateMachineFactory) : base(context, enemyStateMachineFactory) { }

    public override void Enter()
    {
    }
    public override void Perform()
    {
        PatrolCycle();
        CheckSwitchState();
    }

    public override void Exit()
    {
    }

    public override void CheckSwitchState()
    {
        if (_ctx.FOV.canSeePlayer)
        {
            switchState(_factory.detected());
        }
    }

    public void PatrolCycle()
    {
        if (_ctx.Agent.remainingDistance < 0.2f)
        {
            if (waypointIndex < _ctx.path.waypoints.Count - 1)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex = 0;
            }
            _ctx.Agent.SetDestination(_ctx.path.waypoints[waypointIndex].position);


        }
    }
}
