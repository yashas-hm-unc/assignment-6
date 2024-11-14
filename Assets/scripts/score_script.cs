using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_script : MonoBehaviour
{
    public int score=0;
    public TextMeshProUGUI enemyCountText;
    public TextMeshProUGUI elapsed_time_text;
    private float elapsed_time = 0.0f;
    private bool finished = false;
    // Start is called before the first frame updat

    //public void addScore()
    //{
    //    score += 1;
    //}

    public void start()
    {
        elapsed_time = 0;
        elapsed_time_text.text = "Time elapsed: " + elapsed_time.ToString("F2") + " s";
    }

    public void Update()
    {
        if (!finished)
        {
            elapsed_time += Time.deltaTime;
            elapsed_time_text.text = "Time elapsed: " + elapsed_time.ToString("F2") + " s";
        }
    }


    [ContextMenu("update count")]
    public void UpdateEnemyCount(int count)
    {
        //score += 1;
        if(count == 0)
        {
            finished = true;
        }
        enemyCountText.text = "Enemies Remaining: " + count.ToString(); 
    }
}
