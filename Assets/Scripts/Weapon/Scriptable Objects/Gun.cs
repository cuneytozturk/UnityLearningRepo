using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private  GunData gunData;

    // Start is called before the first frame update
    void Start()
    {
        PlayerShoot.shootInput += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot() {
        Debug.Log("pew");
    }
}
