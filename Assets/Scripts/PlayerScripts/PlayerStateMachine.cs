using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    //input
    private InputManage inputManager;
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
    public Vector3 currentMovement = Vector3.zero;
    private Vector3 appliedMovement = Vector3.zero;
    [SerializeField]
    private bool isMovementPressed;
    private bool isRunPressed;
    private bool isJumpPressed;
    private bool isGrounded;

    //vars
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float gravity = -9.8f;
    [SerializeField]
    private float runSpeedMultiplier = 3.0f;
    
   


    void Awake()
    {
        inputManager = GetComponent<InputManage>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        _states = new PlayerStateMachineFactory(this);
        activeState = _states.Grounded();
        activeState.Enter();
        
    }

    void FixedUpdate()
    {
        isGrounded = controller.isGrounded;
        isMovementPressed = inputManager.IsMovementPressed;
        isRunPressed = inputManager.IsRunPressed;
        isJumpPressed = inputManager.IsJumpPressed;

        currentMovement = inputManager.AppliedMovement;
        Controller.Move(transform.TransformDirection(currentMovement) * speed * Time.deltaTime);
        activeState.PerformStates();
        Controller.Move(appliedMovement * Time.deltaTime);





        Debug.Log(currentMovement);

    }

    //getters and setters
    public float Speed { get { return speed; } set { speed = value; } }
    public bool IsMovementPressed { get { return isMovementPressed; } set { isMovementPressed = value; } }
    public CharacterController Controller { get { return controller; } set { controller = value; } }
    //public Vector3 PlayerVelocity { get { return playerVelocity; } set { playerVelocity = value; } }

    //public float PlayerVelocityY { get { return playerVelocity.y; } set { playerVelocity.y = value; } }
    public float Gravity { get { return gravity; } set { gravity = value; } }
    public Vector2 MovementInput { get { return movementInput; } }
    public bool IsRunPressed { get { return isRunPressed; } set { isRunPressed = value; } }
    public PlayerInput.OnFootActions OnFootActions { get { return onFoot; } }
    public float AppliedMovementX { get { return appliedMovement.x; } set { appliedMovement.x = value; } }
    public float AppliedMovementZ { get { return appliedMovement.z; } set { appliedMovement.z = value; } }
    public float AppliedMovementY { get { return appliedMovement.y; } set { appliedMovement.y = value; } }

    public Vector3 AppliedMovement { get { return appliedMovement; } set { appliedMovement = value; } }

    public Vector3 MoveDirection { get { return moveDirection; } set { moveDirection = value; } }
    public Animator Animator { get { return animator; } set { animator = value; } }
    public int IsWalkingHash { get { return isWalkingHash; } }
    public int IsRunningHash { get { return isRunningHash; } }
    public PlayerBaseState ActiveState { get { return activeState; } set { activeState = value; } }

    public bool IsJumpPressed { get { return isJumpPressed; } }
    public float RunSpeedMultiplier { get { return runSpeedMultiplier; } set { runSpeedMultiplier = value; } }
    public bool IsGrounded { get { return isGrounded; } }


}
