using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy_gun : Weapon_def
{
    public int magsize = 1;
    public float firerate = 1f; // firerate/sec
    public int damage = 10;
    public Transform moozle;//position of the mozzle 
    public string projectilename = "bullet0";//name which finde the ammo pool



    int magleft = 1;
    float lastfire=0f;


    void Start()
    {
        magleft = magsize;

    }


    public override void pull()
    {
        if (Time.time > lastfire + 1 / firerate)
        {
            Vector3 dir = moozle.forward;
            Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
            GameObject temp = poolmanagger.POOL.Spawn(projectilename, moozle.position, rot);

            lastfire = Time.time;
        }
            
    }

    public override void release()
    {
       
    }

    public override void reload()
    {
        throw new System.NotImplementedException();
    }



    /*
    private void OnTriggerEnter(Collider other)
    {
        isincontact = true;
        contact = other;
    }
    private void OnTriggerStay(Collider other)
    {
        isincontact = true;
        contact = other;
    }
    private void OnTriggerExit(Collider other)
    {
        isincontact = false;
        contact = null;
    }*/
}
