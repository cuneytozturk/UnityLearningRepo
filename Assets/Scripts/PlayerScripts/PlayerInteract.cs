using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManage inputManager;
    
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        cam = GetComponent<PlayerLook>().cam;
        inputManager = GetComponent<InputManage>();
    }

    
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        
        //casts ray out forwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward); 
        RaycastHit hitInfo;

        //if ray hits something
        if (Physics.Raycast(ray, out hitInfo, distance, mask)){

            //and the object is interactable
            if(hitInfo.collider.GetComponent<Interactable>() != null){
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                //if player presses interact prompt
                if (inputManager.IsInteractPressed){
                    interactable.BaseInteract();
                 }
            }
        };
    }
}
