using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanagger : MonoBehaviour
{
    // Start is called before the first frame update
    public static Datamanagger Single;
    public Settings_Data settings;
    //Player_data;
    public string filename = "settings.xml";


    public bool refresh = false;


    private void Awake()
    {
        Single = this;
    }

    void Start()
    {
        
        settings = Settings_Data.loadData(filename);
        //if (settings == null)
        //{
            //settings = new Settings_Data();
        //settings.saveData(filename);
        //}
        //settings.setvolume();
    }

    // Update is called once per frame
    void Update()
    {
       /* if(refresh)
        {
            refresh = false;
            settings.setvolume();
        }*/
    }
}


