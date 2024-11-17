using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oculus.Interaction;
using UnityEngine;

public class logsnap : MonoBehaviour
{
    [SerializeField]
    private SnapInteractable snapinteractable;

    public Color default_color;

    [SerializeField]
    public int snapinteractable_id;

    [SerializeField]
    private PuzzleManager puzzleManager;

    private GameObject last_selected_key;

    Dictionary<int, Color> key_color_mappings = new Dictionary<int, Color> {
        {1, Color.red},
        {2, Color.blue},
        {3, Color.green }};

    public void GetSelectingInteractorId()
    {
        // Get all of the interactors that are currently selecting
        if (snapinteractable.SelectingInteractorViews.Any())
        {
            
            
            //Debug.Log("Selecting interactor with id ");
            foreach (IInteractorView interactorView in snapinteractable.SelectingInteractorViews)
            {
                GameObject key = interactorView.Data as MonoBehaviour ? ( (MonoBehaviour)interactorView.Data).gameObject : null;
                last_selected_key = key.transform.parent.gameObject;
                Transform interactable_plane_tranform = transform.parent.transform.Find("Plane");
                
                if (interactable_plane_tranform != null)
                {
                    SoundFXManager.instance.PlaySetClip(1, transform, 1.0f);
                    Renderer renderer = interactable_plane_tranform.gameObject.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        key_script keyscript = key.transform.parent.gameObject.GetComponent<key_script>();
                        int keyscript_id = keyscript.key_id;
                        renderer.material.color = key_color_mappings.GetValueOrDefault(keyscript_id);
                        ChangeColor(key_color_mappings.GetValueOrDefault(keyscript_id));
                    }
                }

                if (puzzleManager != null)
                {
                    key_script keyscript = key.transform.parent.gameObject.GetComponent<key_script>();

                    if (keyscript != null)
                    {
                        Debug.Log("keyscript is not null");
                        int keyscript_id = keyscript.key_id;
                        bool isCorrect;

                        isCorrect = puzzleManager.update_current_state(snapinteractable_id, keyscript_id);

                        ChangeInteractableColor(keyscript_id);
                        if(isCorrect)
                        {
                            ChangeInteractorVisual(true);
                        }
                        
                    }
                    
                }
            }
        }
    }

    void ChangeInteractorVisual(bool isCorrect)
    {

        //Debug.Log("key name is : " + last_selected_key.name);
        GameObject Capsule_filler = last_selected_key.transform.Find("Capsule_filler").gameObject;

        //foreach(Transform child in last_selected_key.transform.)

        Material material = Capsule_filler.GetComponent<MeshRenderer>().material;

        Vector2 new_value;
        float pulse_speed;
        if(isCorrect)
        {
            new_value = new Vector2(0.0f, 1.0f);
            pulse_speed = 5.0f;
        }

        else
        {
            new_value = new Vector2(0.75f, 1.0f);
            pulse_speed = 0.0f;
        }

        material.SetVector("_Remap_in_out", new_value);
        material.SetFloat("_PulseSpeed", pulse_speed);
    }

        
    void ChangeInteractableColor(int keyscript_id)
    {
        ChangeColor(key_color_mappings.GetValueOrDefault(keyscript_id));
    }

    public void onDeselect()
    {
        if (!Application.isPlaying) return;
        GameObject parent = transform.parent.gameObject;
        Transform interactable_plane_tranform = parent.transform.Find("Plane");


        SoundFXManager.instance.PlaySetClip(0, transform, 1.0f);

        if (interactable_plane_tranform != null)
        {
            Renderer renderer = interactable_plane_tranform.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                //renderer.material.color = default_color;
                ChangeColor(default_color);
            }
        }

        if(puzzleManager != null)
        {
            puzzleManager.update_current_state(snapinteractable_id, -1);
            ChangeInteractorVisual(false);
        }
    }

    public void ChangeColor(Color color)
    {
        GameObject parent = transform.parent.gameObject;
        Transform interactable_plane_tranform = parent.transform.Find("Plane");

        if (interactable_plane_tranform != null && !snapinteractable.SelectingInteractorViews.Any())
        {
            Renderer renderer = interactable_plane_tranform.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.SetColor("_KeyCoreColor", color);
                //renderer.material.color = color;
            }
        }
    }
}
