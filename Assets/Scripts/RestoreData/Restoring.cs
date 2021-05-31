using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restoring : MonoBehaviour
{
    private int maxSavedDataSize = 500;
    private Restorable[] restorables;
    private List<List<SavedData>> data;
    private bool rewinding = false;

    void Start()
    {
        restorables = FindObjectsOfType<Restorable>();
        data = new List<List<SavedData>>();
        for(var i = 0; i < restorables.Length; i++)
        {
            var currentData = new List<SavedData>();

            data.Add(currentData);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartRewinding();
        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            StopRewinding();
        }

        if(rewinding)
            Rewind();
        else
            Record();
    }

    void StartRewinding()
    {
        rewinding = true;
        for(var i = 0; i < restorables.Length; i++)
            restorables[i].Enabled = false;
    }

    void StopRewinding()
    {
        SavedData currentSavedData;
        rewinding = false;
        for(var i = 0; i < restorables.Length; i++)
        {
            restorables[i].Enabled = true;
            if(data[i].Count > 0)
            {
                currentSavedData = data[i][0];
                restorables[i].RestoreData(currentSavedData, true);
            }
        }
    }

    void Rewind()
    {
        for(var i = 0; i < restorables.Length; i++)
        {
            List<SavedData> currentData = data[i];

            if(currentData.Count > 0)
            {
                SavedData currentSavedData = currentData[0];

                if(currentData.Count > 1)
                    currentData.RemoveAt(0);
                restorables[i].RestoreData(currentSavedData);
            }
        }
    }

    void Record()
    {
        for(var i = 0; i < restorables.Length; i++)
        {
            List<SavedData> currentData = data[i];

            if(currentData.Count > maxSavedDataSize)
                currentData.RemoveAt(currentData.Count - 1);
            currentData.Insert(0, restorables[i].GetSavedData());
        }
    }
}
