using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class User_Input : MonoBehaviour
{
    public static User_Input Single; 
    public float Forward = 0;
    public float Right = 0;
    public float raw_v=0;
    public float raw_h=0;

    //Button events that not controled by accessories 
    //public UnityEvent //Fire1, Fire2,
                    //reload, inventory,
                   // b1,b2,b3,b4,
                  //  Use;
    
    void Awake()
    {
        if(Single==null || Single!=Single)
            Single = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Fire1.AddListener(echo);
        // b1.AddListener(echo2);
        Cursor.lockState = CursorLockMode.Locked;
    }
  /*  void echo()
    {
        Debug.Log("Hello from event fire1");
    }
    void echo2()
    {
        Debug.Log("Hello from event b1");
    }*/
    // Update is called once per frame
    void Update()
    {
        //get Forward inpusts
        if (GameInputManager.GetKey("forward"))
            Forward = 1;
        else if (GameInputManager.GetKey("backward"))
            Forward = -1;
        else
            Forward = 0;

        if (GameInputManager.GetKey("right"))
            Right = 1;
        else if (GameInputManager.GetKey("left"))
            Right = -1;
        else
            Right = 0;

        raw_v = Input.GetAxis("Mouse Y") * Datamanagger.Single.settings.sensitivity;
        raw_h = Input.GetAxis("Mouse X")  * Datamanagger.Single.settings.sensitivity;


        //get buttons inputs 
        if(Input.GetMouseButtonDown(0))
        {
            //Fire1.Invoke();
        }

        //InputManagger




        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           // b1.Invoke();
        }


    }
}
