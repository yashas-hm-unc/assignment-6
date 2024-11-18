using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureHandler : MonoBehaviour
{
    // Start is called before the first frame update
    // 0 => Thumbs up left, 1 => Thumbs down left, 2 => Nin left
    // 3 => Thumbs up right, 4 => Thumbs down right, 5 => Nin right
    private bool[] gestureState = { false, false, false, false, false };
    List<List<int>> solveState = new List<List<int>>();
    private int stage = -1;
    public int frameLimit = 50;
    private int frames = 0;
    private bool stop = false;

    public GameObject puzzlecandle3;

    public GameObject finish_manager_go;

    void Start()
    {
        solveState.Add(new List<int> { 0, 4 });
        solveState.Add(new List<int> { 3, 1 });
        solveState.Add(new List<int> { 2, 5 });
        //public float gestureThreshold;
    }

    [ContextMenu("check_candle")]
    void updateState()
    {
        //stage = solveState.Count;
        if (stage < solveState.Count)
        {
            if (gestureState[solveState[stage + 1][0]] && gestureState[solveState[stage + 1][1]])
            {
                stage++;
                SoundFXManager.instance.PlaySetClip(4, transform, 1.0f);
                frames = 0;
            }
        }
        if (stage == solveState.Count)
        {
            if (stop)
                return;
            stop = true;
            SoundFXManager.instance.PlaySetClip(3, transform, 1.0f);

            puzzlecandle3.transform.Find("Point Light").gameObject.SetActive(true);
            puzzlecandle3.transform.Find("Particle System").gameObject.SetActive(true);

            finish_manager finish_script = finish_manager_go.GetComponent<finish_manager>();
            finish_script.finished_puzzle();


            stage = -1;
            frames = 0;
        }
    }

    public void updateGestureStateTrue(int a)
    {
        gestureState[a] = true;
    }

    public void updateGestureStateFalse(int a)
    {
        gestureState[a] = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames += 1;
        if (frames >= 50)
        {
            frames = 0;
            stage = -1;
        }
        updateState();
    }
}
