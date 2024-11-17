using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DigitNumberScript : MonoBehaviour
{
    public TextMeshPro codeTextValue;

    public void addDigit(string digit)
    {
        if (digit.Equals("Good job!"))
        {
            codeTextValue.text = "Good job!";
        }

        if (!codeTextValue.text.Equals("Good job!"))
        {
            if (digit.Equals("X"))
            {
                if (codeTextValue.text == "Enter Code" || codeTextValue.text == "" || codeTextValue.text == "Wrong")
                {
                    codeTextValue.text = "";
                }
                else
                {
                    codeTextValue.text = codeTextValue.text.Substring(0, (codeTextValue.text.Length - 1));
                }
            }
            else if (digit.Equals("C"))
            {
                codeTextValue.text = "Enter Code";
            }
            else
            {
                if (codeTextValue.text == "Enter Code" || codeTextValue.text == "Wrong")
                {
                    codeTextValue.text = "";
                }
                codeTextValue.text += digit;
            }
        }
       
    }
    public string getDigit()
    {
        return codeTextValue.text;
    }

    public void wrongAnswer()
    {
        codeTextValue.text = "Wrong";
    }
}
