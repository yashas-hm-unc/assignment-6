using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContact : MonoBehaviour
{
    public Button button; // Assign the button in the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        button.onClick.Invoke();
    }
    
}
