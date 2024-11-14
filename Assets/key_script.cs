using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_script : MonoBehaviour
{

    //[Serializable]
    public int key_id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void set_key_id(int key_id)
    {
        this.key_id = key_id;
        gameObject.SetActive(false);
    }
}
