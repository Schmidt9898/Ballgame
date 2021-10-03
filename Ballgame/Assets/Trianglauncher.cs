using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trianglauncher : Weapon_def
{

    public int magsize = 1;
    public float firerate = 1f; // firerate/sec
    public int damage = 10;
    public Transform moozle;//position of the mozzle 
    public string projectilename = "bullet0";//name which finde the ammo pool


    public Transform head;

    int magleft = 1;
    float lastfire = 0f;






    void Start()
    {
        magleft = magsize;

    }

    public override void pull()
    {
        throw new System.NotImplementedException();
    }

    public override void release()
    {
        throw new System.NotImplementedException();
    }

    public override void reload()
    {
        throw new System.NotImplementedException();
    }



    // Update is called once per frame
    void Update()
    {
        head.rotation = Quaternion.LookRotation(targetpoint - head.position, Vector3.up);

    }
}
