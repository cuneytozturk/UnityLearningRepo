using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    //input
    private InputManage playerInput;
    private PlayerInput.OnFootActions onFoot;

    //animator
    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;

    //movement state machine
    private PlayerBaseState activeState;
    private PlayerStateMachineFactory _states;

    //movement
    private CharacterController controller;
    private Vector2 movementInput;
    private Vector3 moveDirection;
    private Vector3 playerVelocity;
    private Vector3 appliedMovement = Vector3.zero;
    private bool isMovementPressed;
    private bool isRunPressed;

    //vars
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float gravity = -9.8f;


    void Awake()
    {
        playerInput = GetComponent<InputManage>();
        onFoot = playerInput.OnFootActions;
        controller = GetComponent<CharacterController>();

        onFoot.Run.started += ctx => onRun(ctx);
        onFoot.Run.canceled += ctx => onRun(ctx);
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        _states = new PlayerStateMachineFactory(this);
        activeState = _states.Idle();
        activeState.Enter();
    }

    void FixedUpdate()
    {
        //perform the active state
        activeState.Perform();
        
        //read value from keyboard
        movementInput = onFoot.Movement.ReadValue<Vector2>();
        //transform it into a direction, because transform is a monobehaviour function and cannot be used in the states themselves
        moveDirection=transform.TransformDirection(appliedMovement);
    }

    public void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    //getters and setters
    public float Speed { get { return speed; } set { speed = value; } }
    public bool IsMovementPressed { get { return isMovementPressed; } set { isMovementPressed = value; } }
    public CharacterController Controller { get { return controller; } set { controller = value; } }
    public Vector3 PlayerVelocity { get { return playerVelocity; } set { playerVelocity = value; } }

    public float PlayerVelocityY { get { return playerVelocity.y; } set { playerVelocity.y = value; } }
    public float Gravity { get { return gravity; } set { gravity = value; } }
    public Vector2 MovementInput { get { return movementInput; } }
    public bool IsRunPressed { get { return isRunPressed; } set { isRunPressed = value; } }
    public PlayerInput.OnFootActions OnFootActions { get { return onFoot; } }
    public float AppliedMovementX { get { return appliedMovement.x; } set { appliedMovement.x = value; } }
    public float AppliedMovementZ { get { return appliedMovement.z; } set { appliedMovement.z = value; } }
    public Vector3 MoveDirection { get { return moveDirection; } set { moveDirection = value; } }
    public Animator Animator { get { return animator; } set { animator = value; } }
    public int IsWalkingHash { get { return isWalkingHash; } }
    public int IsRunningHash { get { return isRunningHash; } }
    public PlayerBaseState ActiveState { get { return activeState; } set { activeState = value; } }
}
