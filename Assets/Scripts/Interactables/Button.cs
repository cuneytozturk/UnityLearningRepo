using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{   
    [SerializeField]
    private GameObject wall;
    private bool wallOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact(){
        wallOpen= !wallOpen;
        wall.GetComponent<Animator>().SetBool("isOpen", wallOpen);
    }
}
