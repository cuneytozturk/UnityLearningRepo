using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : Interactable
{
    [SerializeField]
    private PlayerHealth player;
    [SerializeField]
    private float damage;

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
        player.TakeDamage(damage);
    }
}
