using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private InputManage inputManager;
    public static Action shootInput;

    private void Awake()
    {
        inputManager = GetComponent<InputManage>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.PlayerInput.OnFoot.Shoot.triggered) {
            shootInput?.Invoke();
        }
    }
}
