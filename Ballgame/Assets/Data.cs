using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Data
{


    [Header("mouse settings")]
    public float sensitivity=100f;

    [Header("sound settings")]
    public float sound_Master=1;
    public float sound_enviroment=1;
    public float sound_music=1;

    //[Header("Key bindings")]
    public string[] keyMaps;
    public KeyCode[] defaults;


    public Settings_Data()
    {
        keyMaps = GameInputManager.keyMaps;
        defaults = GameInputManager.defaults;
    }
    public static Settings_Data loadData(string filename)
    {
        if (Application.isEditor)
        { 
            var t = new Settings_Data();
            t.saveData(filename);
            return t;
        }


        var temp = new Settings_Data();
        try
        {
        System.IO.FileStream fs = new System.IO.FileStream( filename, System.IO.FileMode.Open);

        System.Xml.Serialization.XmlSerializer Xs = new System.Xml.Serialization.XmlSerializer(temp.GetType());
        temp = (Settings_Data) Xs.Deserialize(fs);

        fs.Close();
           
            return temp;
        }catch
        {
            Debug.LogError("Ther is no such file, creating " + filename);
            temp.saveData(filename);
            return temp;
        }
    }
    public void saveData(string filename)
    {

        System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.OpenOrCreate);
           


        System.Xml.Serialization.XmlSerializer Xs = new System.Xml.Serialization.XmlSerializer(this.GetType());
        Xs.Serialize(fs, this);
        fs.Flush();
        fs.Close();
    }

    void setvolume()
    {
        var allaudio = GameObject.FindObjectsOfType<AudioSource>();
        //var music = GameObject.FindGameObjectsWithTag("Music");
        foreach(var a in allaudio)
        {
            if(a.tag.Equals("Music"))
            {
                a.volume = sound_music;
            }else
            {
                a.volume = sound_enviroment;
            }
        }
        
    }

}
