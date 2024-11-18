using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadScript : MonoBehaviour
{
    public DigitNumberScript digitNumber;
    [SerializeField] public GameObject puzzlecandle2;

    public void PressEnter()
    {
        if (digitNumber.getDigit() == "042")
        {
            digitNumber.addDigit("C");
            digitNumber.addDigit("Good job!");
            // update state of overall game, as this puzzle has been solved
            puzzlecandle2.transform.Find("Point Light").gameObject.SetActive(true);
            puzzlecandle2.transform.Find("Particle System").gameObject.SetActive(true);
        }
        else if (!(digitNumber.getDigit() == "Good job!"))
        {
            digitNumber.wrongAnswer();
        }
    }
}
