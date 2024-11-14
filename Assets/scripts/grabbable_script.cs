using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbable_script : MonoBehaviour
{
    public Transform grabPoint; // Point where the object will be held
    public bool isGrabbed = false; // Track if the object is grabbed

    void Update()
    {
        if (isGrabbed)
        {
            // Keep the object at the grab point position and rotation
            transform.position = grabPoint.position;
            transform.rotation = grabPoint.rotation;
        }
    }

    public void Grab()
    {
        isGrabbed = true;
        // Optionally disable physics
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        isGrabbed = false;
        // Enable physics when released
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
