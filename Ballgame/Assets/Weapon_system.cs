using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//AKA Atachmentrig

//todo hitlayer
//todo distance difference
//todo hitting other colliders
//todo switch weapons
public class Weapon_system : MonoBehaviour
{
    //public Transform body = null;
    public Transform camararig = null;
    public Transform camera_point = null;


    public LayerMask hitlayer;//TODO

    //rotation information from input
    public Quaternion myrot;
    //float horizontal_rot = 0f;
    //float vertical_rot = 0f;

    //float myspecialxrot = 0;
    //public Weapon_interface[] guns;
    //public int gun_id = -1;

    public Weapon_interface selected_gun;
    public float camera_offset = 3f;

    void Start()
    {
    


    }

    // Update is called once per frame
    void Update()
    {
        getInputs();

        getTarget();

        //Turn_to_target();

        if(selected_gun.isincontact)
        {
            Debug.Log("hello from the good place");
        }

    }
    private void LateUpdate()
    {
        Turn_to_target();

    }

    void getInputs()
    {
        //TODO remap for inputs
        if (Input.GetMouseButtonDown(0))
        {
            selected_gun.pull();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            selected_gun.release();
        }
        /*if(Input.GetKeyDown(KeyCode.F))
        {
            anim.Deploy();
            Debug.Log("F");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.Retract();
        }*/
        /*
        m = Input.mouseScrollDelta.y;
        if (m > 0)
            gun_id = 1;
        else if (m < 0)
            gun_id = 0;*/
        /*
         * if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            gun_id = 0;
            selected_gun.gameObject.SetActive(false);
            selected_gun = guns[gun_id];
            selected_gun.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            gun_id = 1;
            selected_gun.gameObject.SetActive(false);
            selected_gun = guns[gun_id];
            selected_gun.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            gun_id = 2;
            selected_gun.gameObject.SetActive(false);
            selected_gun = guns[gun_id];
            selected_gun.gameObject.SetActive(true);
        }*/
    }


    bool has_target = false;
    RaycastHit hit;
    public float target_max_distance = 200f;



    void getTarget()
    {
        if (has_target=Physics.Raycast(camera_point.transform.position /*+ camera_point.transform.forward * camera_offset*/, camera_point.transform.forward, out hit, 1000f, hitlayer))
        {
            Debug.DrawLine(camera_point.transform.position, hit.point, Color.red);

            selected_gun.targetpoint = hit.point;

        }
        else
        {
            selected_gun.targetpoint = camera_point.transform.position + camera_point.transform.forward * 200f;

        }


    }

    Quaternion new_rot;
    void Turn_to_target()
    {
        if(has_target)
        {
            Vector3 to =hit.point-transform.position;//A->B = B-A
            new_rot = Quaternion.LookRotation(to,Vector3.up);
            Debug.DrawLine(transform.position, transform.position + to);   

        }else
        {
            new_rot = Quaternion.LookRotation(camera_point.transform.position + camera_point.transform.forward * 200f, Vector3.up);
        }

        transform.rotation = Quaternion.Slerp(myrot, new_rot, Time.deltaTime * 10f);
        myrot = transform.rotation;
        
    }
    
    
    
    
    
    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("inside..");
    }*/
}
