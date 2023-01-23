using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapons", menuName ="Weapons/gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;
    public float damage;
    public float range;

    [Header("Reload information")]
    public int currentAmmo;
    public int magSize;
    public float firerate;
    public float reloadTime;
    public bool reloading;

    
}
