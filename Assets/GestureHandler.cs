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
    private AudioSource[] audioSources;
    private int stage = -1;
    public int frameLimit = 50;
    private int frames = 0;
    void Start()
    {
        solveState.Add(new List<int> { 0, 4 });
        solveState.Add(new List<int> { 3, 1 });
        solveState.Add(new List<int> { 2, 5 });
        audioSources = GetComponents<AudioSource>();
        //public float gestureThreshold;
    }

    void updateState()
    {
        if (stage < solveState.Count)
        {
            if (gestureState[solveState[stage + 1][0]] && gestureState[solveState[stage + 1][1]])
            {
                stage++;
                audioSources[0].Play();
                frames = 0;
            }
        }
        if (stage == solveState.Count)
        {
            audioSources[1].Play();
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
