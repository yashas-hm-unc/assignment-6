using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContact : MonoBehaviour
{
    public Button button; // Assign the button in the Inspector


    void OnTriggerEnter(Collider other)
    {
            button.onClick.Invoke(); // Trigger the button's OnClick() event
    }
}
