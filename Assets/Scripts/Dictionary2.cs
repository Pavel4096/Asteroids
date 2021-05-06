using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Dictionary2 : ISerializationCallbackReceiver
{
    public Dictionary<string, string> myDict = new Dictionary<string, string>();
    public List<string> keys;
    public List<string> values;

    public Dictionary2()
    {
        keys = new List<string>();
        values = new List<string>();
    }

    public void OnBeforeSerialize()
    {
        keys = myDict.Keys.ToList();
        values = myDict.Values.ToList();
    }

    public void OnAfterDeserialize()
    {
        myDict.Clear();
        for(var i = 0; i < keys.Count; i++)
        {
            myDict.Add(keys[i], values[i]);
        }
    }
}