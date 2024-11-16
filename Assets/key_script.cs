using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_script : MonoBehaviour
{

    //[Serializable]
    public int key_id;

    private void Start()
    {
        //Renderer renderer = transform.Find("Visuals").gameObject.transform.Find("Root").gameObject.transform.Find("simpleGrabKeyMesh").gameObject.GetComponent<Renderer>();
        //Material material = renderer.material;
        //Color baseEmissionColor = Color.red;
        //float emissionIntensity = 1.0f;

        //Color finalEmissionColor = baseEmissionColor * emissionIntensity;

        //material.EnableKeyword("_EMISSION");
        //material.SetColor("_EmissionColor", finalEmissionColor);

        //DynamicGI.SetEmissive(GetComponent<Renderer>(), finalEmissionColor);
    }
}
