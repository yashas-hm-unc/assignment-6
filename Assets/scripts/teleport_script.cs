using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_script : MonoBehaviour
{
    //public Transform player;
    public float tp_distance = 0.1f;
    public bool teleporting = false;
    //public OVRPlayerController player;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!teleporting)
            {
                teleporting = true;
                Teleport();
            }

        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (!teleporting)
        //    {
        //        teleporting = true;
        //        Teleport();
        //        return;
        //    }
        //    return;

        //}

        else if (OVRInput.GetUp(OVRInput.Button.Three) || Input.GetKeyUp(KeyCode.Space))
        {
            teleporting = false;
        }
    }


    void Teleport()
    {
        if (player != null)
        {
            Vector3 forward = -1 * player.transform.forward;
            Vector3 new_pos = player.transform.position + forward * tp_distance;
            player.transform.position = new_pos;

        }

    }
}
