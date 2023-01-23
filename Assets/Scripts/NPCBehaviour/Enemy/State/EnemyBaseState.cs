public abstract class EnemyBaseState {
    protected EnemyStateMachine _ctx;
    protected EnemyStateMachineFactory _factory;

    public EnemyBaseState(EnemyStateMachine currentContext, EnemyStateMachineFactory enemyStateFactory)
    {
        _ctx = currentContext;
        _factory = enemyStateFactory;
    }

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

    public abstract void CheckSwitchState();

    protected void switchState(EnemyBaseState newstate) {
        Exit();
        newstate.Enter();
        _ctx.ActiveState = newstate;
    } 

}