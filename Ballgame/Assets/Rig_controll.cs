using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig_controll : MonoBehaviour
{
    //Options_Data options;

    Transform mpt = null;
    User_Input usr_input = null;

    public Quaternion myrot;
    float horizontal_rot = 0f;
    float vertical_rot = 0f;


    void Start()
    {
        usr_input = User_Input.Single; //GetComponentInParent<User_Input>();
        if (usr_input == null)
            Debug.LogError("user_input is null.");

        mpt = transform.parent;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = mpt.position;

        horizontal_rot += usr_input.raw_h*Time.deltaTime;
        vertical_rot -= usr_input.raw_v * Time.deltaTime;
        vertical_rot = Mathf.Clamp(vertical_rot, -45, 80);
        transform.rotation = Quaternion.Euler(vertical_rot, horizontal_rot, 0);



    }
}
