using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{

    private int[] required_states;
    private int[] current_state;

    public TextMeshProUGUI winText;

    [SerializeField]
    public SnapInteractable[] snap_interactables;

    [SerializeField]
    public SnapInteractor[] snap_interactors;

    private float curr_timer;

    public float shuffle_interval;
    private float next_shuffle_time = 0.0f;
    private int correct_count;

    public 

    // Start is called before the first frame update
    void Start()
    {
        curr_timer = 0.0f;
        correct_count = 0;
        required_states = new int[] { 1, 2, 3, 4 };
        current_state = new int[] { -1, -1, -1, -1 };
    }

    // Update is called once per frame
    void Update()
    {
        curr_timer += Time.deltaTime;
        if(Time.time > next_shuffle_time)
        {
            Shuffle_Assignments();
            Assign_Colors();
            next_shuffle_time = Time.time + shuffle_interval;
        }
    }

    [ContextMenu("Shuffle_Assignments")]
    void Shuffle_Assignments()
    {
        System.Random random = new System.Random();
        for (int i= required_states.Length - 1; i>0; i--)
        {
            int randomIndex = random.Next(0, i + 1);
            int temp = required_states[i];
            required_states[i] = required_states[randomIndex];
            required_states[randomIndex] = temp;
        }

    }

    //Updates a particular State
    public bool update_current_state(int a, int b)
    {
        current_state[a] = b;
        check_states();

        return current_state[a] == required_states[a];
    }

    //checks all the states, and print if puzzle is solved.
    void check_states()
    {
        correct_count = 0;
        for(int i=0; i <required_states.Length; i++)
        {
            if(required_states[i] == current_state[i])
            {
                correct_count++;
            }
        }

        if(correct_count == 3)
        {
            //Debug.Log("You have solved Advait's puzzle");
            winText.text = "You have solved Advait's puzzle!!";
        }


    }


    void Assign_Colors()
    {

        for(int i=0; i < required_states.Length; i++)
        {
            int req_state = required_states[i];
            logsnap logsnap_script = snap_interactables[i].GetComponent<logsnap>();
            if (req_state == 1)
            {
                logsnap_script.default_color = Color.red;
                logsnap_script.ChangeColor(Color.red);
            }

            else if (req_state == 2)
            {
                logsnap_script.default_color = Color.blue;
                logsnap_script.ChangeColor(Color.blue);
            }

            else if (req_state == 3)
            {
                logsnap_script.default_color = Color.green;
                logsnap_script.ChangeColor(Color.green);
            }
            else
            {
                logsnap_script.default_color = Color.white;
                logsnap_script.ChangeColor(Color.white);
            }
        }
    }

}
