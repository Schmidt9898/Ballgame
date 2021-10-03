using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rectanglegun : Weapon_def
{

    public int max_ammo = 10;
    int ammo_count;
    public float firerate = 2f; // 1/sec


    public Transform moozle;
    public string projectilename = "bullet1";


    float lastfire = 0f;
    public override void pull()
    {
        if (ammo_count>0 && Time.time > lastfire + 1 / firerate)
        {
            //var par = moozle.GetComponent<ParticleSystem>();
            //par.Play();
            ammo_count--;
            Vector3 dir = moozle.forward;//targetpoint - moozle.position;
            Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
            //GameObject temp = Instantiate(projectile, moozle[moozleid].position, rot);
            GameObject temp = poolmanagger.POOL.Spawn(projectilename, moozle.position, rot);

            lastfire = Time.time;
            //audio.Play();
        }
    }

    public override void release()
    {
        //throw new System.NotImplementedException();
    }

    public override void reload()
    {
        ammo_count = max_ammo;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammo_count = max_ammo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
