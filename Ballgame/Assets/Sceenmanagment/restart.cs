using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
            Application.LoadLevel(Application.loadedLevel);
        if(Input.GetKeyDown(KeyCode.Escape) && !Application.isEditor)
        {
            Application.Quit();
        }
    }
}
