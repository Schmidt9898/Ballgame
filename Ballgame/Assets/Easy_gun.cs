using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy_gun : Weapon_interface
{
    // Start is called before the first frame update
    public int max_ammo = 10;
    int ammo_count;
    public float firerate = 1f; // 1/sec
    
    
    public Transform moozle;
    public string projectilename="bullet0";
    //public AudioSource audio;




    void Start()
    {
        ammo_count = max_ammo;

    }

    float lastfire=0f;

    public override void pull()
    {
        if (Time.time > lastfire + 1 / firerate)
        {
            //var par = moozle.GetComponent<ParticleSystem>();
            //par.Play();
            Vector3 dir = moozle.forward;//targetpoint - moozle.position;
            Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
            //GameObject temp = Instantiate(projectile, moozle[moozleid].position, rot);
            GameObject temp = poolmanagger.POOL.Spawn(projectilename, moozle.position, rot);

            lastfire = Time.time;
            //audio.Play();
        }
        //GameObject temp = Instantiate(projectile, moozle.position, moozle.rotation);
    }

    public override void release()
    {
       // throw new System.NotImplementedException();
    }

    public override void reload()
    {
        throw new System.NotImplementedException();
    }




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
    }
}
