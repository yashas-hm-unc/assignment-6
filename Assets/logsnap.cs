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

    public void GetSelectingInteractorId()
    {
        // Get all of the interactors that are currently selecting
        if (snapinteractable.SelectingInteractorViews.Any())
        {
            
            //Debug.Log("Selecting interactor with id ");
            foreach (IInteractorView interactorView in snapinteractable.SelectingInteractorViews)
            {
                GameObject key = interactorView.Data as MonoBehaviour ? ( (MonoBehaviour)interactorView.Data).gameObject : null;
                GameObject parent = transform.parent.gameObject;
                Transform interactable_plane_tranform = parent.transform.Find("Plane");
                
                if (interactable_plane_tranform != null)
                {
                    Renderer renderer = interactable_plane_tranform.gameObject.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material.color = Color.red;
                    }
                }

                if (puzzleManager != null)
                {
                    key_script keyscript = key.transform.parent.gameObject.GetComponent<key_script>();
                    Debug.Log("parent name is : " + key.transform.parent.gameObject.name);

                    if (keyscript != null)
                    {
                        Debug.Log("keyscript is not null");
                        int keyscript_id = keyscript.key_id;
                        puzzleManager.update_current_state(snapinteractable_id, keyscript_id);

                        if(keyscript_id == 1)
                        {
                            ChangeColor(Color.red);
                        }

                        else if (keyscript_id == 2)
                        {
                            ChangeColor(Color.blue);
                        }

                        else if (keyscript_id == 3)
                        {
                            ChangeColor(Color.green);
                        }
                    }

                    
                }
            }
        }
    }

    public void onDeselect()
    {
        GameObject parent = transform.parent.gameObject;
        Transform interactable_plane_tranform = parent.transform.Find("Plane");
        
        if (interactable_plane_tranform != null)
        {
            Renderer renderer = interactable_plane_tranform.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = default_color;
            }
        }

        if(puzzleManager != null)
        {
            puzzleManager.update_current_state(snapinteractable_id, -1);
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
                renderer.material.color = color;
            }
        }
    }
}
