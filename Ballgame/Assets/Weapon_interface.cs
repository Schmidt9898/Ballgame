using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon_interface:MonoBehaviour
{

    
    public Vector3 targetpoint=Vector3.zero;
    public bool isincontact = false;
    public Collider contact;

    
    public abstract void pull();
    public abstract void release();
    public abstract void reload();


}
