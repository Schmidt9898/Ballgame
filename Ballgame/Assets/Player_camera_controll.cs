using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will change between two cameramod
//this will may be moved to other file

public class Player_camera_controll : MonoBehaviour
{
    
    public Cinemachine.CinemachineVirtualCamera virtualCamera_0, virtualCamera_1;
    //higher prioriti the selected camera
    private void Start()
    {
        virtualCamera_0.Priority = 1;
        virtualCamera_1.Priority = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            //selected = virtualCamera_0;
            virtualCamera_0.Priority = 0;
            virtualCamera_1.Priority = 1;
        }else if(Input.GetMouseButtonUp(1))
        {
            virtualCamera_0.Priority = 1;
            virtualCamera_1.Priority = 0;
        }
    }

}
