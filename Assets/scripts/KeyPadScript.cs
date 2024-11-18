using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadScript : MonoBehaviour
{
    public DigitNumberScript digitNumber;
    [SerializeField] public GameObject puzzlecandle2;
    public GameObject finish_manager_go;
    public int temp = 0;
    private bool stop = false;


    //void Update()
    //{
    //    if (stop)
    //        return;

    //    //finish_manager.instance.finished_puzzle();
    //    finish_manager finish_script = finish_manager_go.GetComponent<finish_manager>();
    //    finish_script.finished_puzzle();
    //    digitNumber.addDigit("C");
    //    digitNumber.addDigit("Good job!");
    //    // update state of overall game, as this puzzle has been solved
    //    puzzlecandle2.transform.Find("Point Light").gameObject.SetActive(true);
    //    puzzlecandle2.transform.Find("Particle System").gameObject.SetActive(true);
    //    stop = true;
    //}

    public void PressEnter()
    {
        if (digitNumber.getDigit() == "042")
        {
            if (stop)
                return;

            //finish_manager.instance.finished_puzzle();
            finish_manager finish_script = finish_manager_go.GetComponent<finish_manager>();
            finish_script.finished_puzzle();
            digitNumber.addDigit("C");
            digitNumber.addDigit("Good job!");
            // update state of overall game, as this puzzle has been solved
            puzzlecandle2.transform.Find("Point Light").gameObject.SetActive(true);
            puzzlecandle2.transform.Find("Particle System").gameObject.SetActive(true);
            stop = true;
        }
        else if (!(digitNumber.getDigit() == "Good job!"))
        {
            digitNumber.wrongAnswer();
        }
    }
}
