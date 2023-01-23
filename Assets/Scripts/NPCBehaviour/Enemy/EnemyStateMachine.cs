using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Path path;
    private FieldOfView fov;

    private EnemyBaseState activeState;
    public PatrolState patrolState;
    private EnemyStateMachineFactory _states;


    private void Awake()
    {
        _states = new EnemyStateMachineFactory(this);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();
        activeState = _states.patrol();
    }

    void Update()
    {
        if(activeState!= null)
        {
            activeState.Perform();
        }
        
    }

   public EnemyBaseState ActiveState { get { return activeState; } set { activeState = value; } }
   public FieldOfView FOV {get { return fov; } }

}
