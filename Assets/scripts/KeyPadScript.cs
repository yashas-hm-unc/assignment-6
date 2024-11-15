using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadScript : MonoBehaviour
{
    public DigitNumberScript digitNumber;
    public GameObject KeyPad;

    public void PressEnter()
    {
        if (digitNumber.getDigit() == "042")
        {
            digitNumber.addDigit("C");
            digitNumber.addDigit("Good job!");
            // update state of overall game, as this puzzle has been solved
        }
        else if (!(digitNumber.getDigit() == "Good job!"))
        {
            digitNumber.wrongAnswer();
        }
    }
}
