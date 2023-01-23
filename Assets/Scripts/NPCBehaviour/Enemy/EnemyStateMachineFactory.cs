    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachineFactory
{
    EnemyStateMachine _context;

    public EnemyStateMachineFactory(EnemyStateMachine currentcontext)
    {
        _context = currentcontext;
    }

    public EnemyBaseState patrol()
    {
        return new PatrolState(_context, this);
    }

    public EnemyBaseState detected() {
        return new DetectedState(_context, this);    
    }
}

