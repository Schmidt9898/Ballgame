using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInputManager
{
    //TODO mouse and load from file throught the load managger
    static Dictionary<string, KeyCode> keyMapping;
    public static string[] keyMaps = new string[11]
    {
        "slot1",
        "slot2",
        "slot3",
        "slot4",
        "reload",
        "inventory",
        "forward",
        "backward",
        "right",
        "left",
        "jump"
    };
    public static KeyCode[] defaults = new KeyCode[11]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.R,
        KeyCode.I,
        KeyCode.W,
        KeyCode.S,
        KeyCode.D,
        KeyCode.A,
        KeyCode.Space
    };

    static GameInputManager()
    {
        InitializeDictionary();
    }

    public static void InitializeDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping.Add(keyMaps[i], defaults[i]);
        }
    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keyMapping.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        keyMapping[keyMap] = key;
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }
    public static bool GetKeyUp(string keyMap)
    {
        return Input.GetKeyUp(keyMapping[keyMap]);
    }
    public static bool GetKey(string keyMap)
    {
        return Input.GetKey(keyMapping[keyMap]);
    }
    /*public static bool GetButton(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }*/
}