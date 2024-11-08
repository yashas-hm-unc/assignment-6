using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f; // Force applied to the bird when it flaps
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for flapping input in Update
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space)) // Use trigger button to flap
        {
            Flap();
        }

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Flap();
        //}
    }

    //void FixedUpdate()
    //{
    //    // Here you can apply additional physics updates if needed
    //}

    void Flap()
    {
        // Apply an upward force to the bird
        rb.velocity = new Vector3(rb.velocity.x, flapForce, rb.velocity.z); // Flap upwards
    }
}
