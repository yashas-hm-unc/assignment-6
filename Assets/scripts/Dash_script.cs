//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Dash_script : MonoBehaviour
//{
//    //if (Input.GetKeyDown(KeyCode.Space) && canDash)

//    public float dashDistance = 5f;
//    public float dashCooldown = 3f;
//    public float dashSpeed = 10f;

//    private bool canDash = true;
//    private float dashCooldownTimer;
//    private Rigidbody rb;

//    public Canvas mycanvas;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
//    }

//    // Update is called once per frame

//    [ContextMenu("check")]
//    public void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space) && canDash)
//        //if (OVRInput.GetDown(OVRInput.Button.Three) && canDash)
//        {
//            Dash();
//        }
//    }

//    //[ContextMenu("Dash check")]
//    //public IEnumerator Dash()
//    //{
//    //    canDash = false;
//    //    dashCooldownTimer = dashCooldown;

//    //    Vector3 dashDirection = transform.forward;

//    //    Vector3 targetPosition = transform.position + dashDirection * dashDistance;

//    //    float dashStartTime = Time.time;

//    //    while (Time.time < dashStartTime + (dashDistance / dashSpeed))
//    //    {
//    //        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * dashSpeed);
//    //        //transform.Translate(transform.forward * dashSpeed * Time.deltaTime);
//    //        yield return null; // Wait for the next frame
//    //    }
//    //}


//    private void Dash()
//    {
//        canDash = false; // Prevent further dashes
//        Vector3 dashDirection = transform.forward * dashDistance; // Calculate dash direction

//        mycanvas = GetComponentInChildren<Canvas>().gameObject;

//        mycanvas.setActive(false);

//        // Apply the dash
//        rb.AddForce(dashDirection, ForceMode.Impulse); // Use Impulse for immediate force

//        // Start cooldown
//        StartCoroutine(DashCooldown());
//    }

//    private System.Collections.IEnumerator DashCooldown()
//    {
//        yield return new WaitForSeconds(dashCooldown); // Wait for cooldown
//        canDash = true; // Reset dash ability
//        mycanvas.setActive(true);
//    }
//}
