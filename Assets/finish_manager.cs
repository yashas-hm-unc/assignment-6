using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class finish_manager : MonoBehaviour
{

    //public static finish_manager instance;

    private float curr_timer;
    public TextMeshProUGUI winText;

    //private bool isFinished = false;
    private int completed_puzzles = 0;


    // Start is called before the first frame update
    void Start()
    {
        curr_timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (completed_puzzles < 3)
        {
            curr_timer += Time.deltaTime;
            winText.text = "Timer : " + curr_timer.ToString("F");
        }

        else
        {
            winText.text = " Congratulations, current Timer : " + curr_timer.ToString("F");
        }

    }

    public void finished_puzzle()
    {
        completed_puzzles += 1;
        Debug.Log("compeleted puzzle, current complete count is : " + completed_puzzles.ToString());
    }



}
