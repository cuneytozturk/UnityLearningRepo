using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private bool isGrounded;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float speed = 5;
    private float gravity = -9.8f;
    public float jumpheight = 3f;
    private bool isMovementPressed;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 runMoveDirection = Vector3.zero;
    public bool isRunPressed;
    private float runMultiplier = 3.0f;

    public float Speed { get { return speed; } set { speed = value; } }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input){
        moveDirection.x=input.x;
        moveDirection.z=input.y;
        isMovementPressed = moveDirection.x != 0 || moveDirection.z!= 0;
        runMoveDirection.x = input.x * runMultiplier;
        runMoveDirection.z = input.y * runMultiplier;

        if (!isRunPressed) { controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); }
        else
        {
            controller.Move(transform.TransformDirection(runMoveDirection) * speed * Time.deltaTime);
        }




        if (isGrounded && playerVelocity.y<0){
        playerVelocity.y=-2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    public void onRun(InputAction.CallbackContext context) {
        isRunPressed = context.ReadValueAsButton();
    }

    public void Jump(){
        if (isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpheight *  -3.0f * gravity);
        }
    }



  
}
