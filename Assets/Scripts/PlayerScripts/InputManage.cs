using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManage : MonoBehaviour
{
    //input
    private PlayerInput playerInput;

    //look
    private PlayerLook playerLook;
    private PlayerShoot playerShoot;
    private bool isRunPressed;
    private Vector3 appliedMovement = Vector3.zero;
    private bool isMovementPressed;
    private bool isInteractPressed;
    private bool isJumpPressed = false;

    void Awake()
    {
        playerInput = new PlayerInput();
        playerLook = GetComponent<PlayerLook>();
        playerShoot = GetComponent<PlayerShoot>();
        playerInput.OnFoot.Run.started += onRun;
        playerInput.OnFoot.Run.canceled += onRun;
        playerInput.OnFoot.Movement.started += onMovementInput;
        playerInput.OnFoot.Movement.canceled += onMovementInput;
        playerInput.OnFoot.Movement.performed += onMovementInput;
        playerInput.OnFoot.Interact.performed += onInteract;
        playerInput.OnFoot.Jump.started += onJump;
        playerInput.OnFoot.Jump.canceled += onJump;


    }

    public void onJump(InputAction.CallbackContext context) {
        isJumpPressed = context.ReadValueAsButton();
    }
    public void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }
    public void onInteract(InputAction.CallbackContext context)
    {
        isInteractPressed = context.ReadValueAsButton();
    }

    public void onMovementInput(InputAction.CallbackContext context) {
        Vector2 movementInput = playerInput.OnFoot.Movement.ReadValue<Vector2>();
        appliedMovement.x = movementInput.x;
        appliedMovement.z = movementInput.y;
        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;

    }

    void Update()
    {
        playerLook.ProcessLook(playerInput.OnFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        playerInput.OnFoot.Enable();
    }

    private void OnDisable()
    {
        playerInput.OnFoot.Disable();
    }
    public PlayerInput PlayerInput { get { return playerInput; } set { playerInput = value; } }
    public bool IsRunPressed { get { return isRunPressed; } set { isRunPressed = value; } }
    public bool IsMovementPressed { get { return isMovementPressed; } set { isMovementPressed = value; } }
    public bool IsInteractPressed { get { return isInteractPressed; } }
    public bool IsJumpPressed { get { return isJumpPressed; } }
    public Vector3 AppliedMovement { get { return appliedMovement; } set { appliedMovement = value; } }

}
