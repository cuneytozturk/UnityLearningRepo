using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachineFactory {
    PlayerStateMachine _context;

    public PlayerStateMachineFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBaseState Idle() { return new IdleState(_context, this); }

    public PlayerBaseState Walking() { return new WalkingState(_context, this); }
    
    public PlayerBaseState Running() { return new RunningState(_context, this); }


}
