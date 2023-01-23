using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : Interactable
{

    [SerializeField] 
    private PlayerHealth health;
    [SerializeField]
    private float hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        health.restoreHealth(hp);   
    }
}
