using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon_def:MonoBehaviour
{

    [HideInInspector]
    public Vector3 targetpoint=Vector3.zero;
    [HideInInspector]
    public bool isincontact = false;
    [HideInInspector]
    public Collider contact;





    public abstract void pull();
    public abstract void release();
    public abstract void reload();


}
