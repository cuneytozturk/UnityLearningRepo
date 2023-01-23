using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManage : MonoBehaviour
{
    //input
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    //look
    private PlayerLook playerLook;
    private PlayerShoot playerShoot;
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerLook = GetComponent<PlayerLook>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    void Update()
    {
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    public PlayerInput.OnFootActions OnFootActions { get { return onFoot; } }


}
