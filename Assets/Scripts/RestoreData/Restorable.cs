using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restorable : MonoBehaviour
{
    private Rigidbody restorableRigidbody;

    public bool Enabled
    {
        set => restorableRigidbody.isKinematic = !value;
    }

    private void Awake()
    {
        restorableRigidbody = GetComponent<Rigidbody>();
    }

    public SavedData GetSavedData()
    {
        var data = new SavedData();

        data.position = transform.position;
        data.rotation = transform.rotation;
        data.velocity = restorableRigidbody.velocity;
        data.angularVelocity = restorableRigidbody.angularVelocity;

        return data;
    }

    public void RestoreData(SavedData data, bool fullRestore = false)
    {
        transform.position = data.position;
        transform.rotation = data.rotation;

        if(fullRestore)
        {
            restorableRigidbody.velocity = data.velocity;
            restorableRigidbody.angularVelocity = data.angularVelocity;
        }
    }
}
