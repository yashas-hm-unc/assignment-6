using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXobject;

    [SerializeField]
    private AudioClip key_pickup;

    [SerializeField]
    private AudioClip key_snap_interact;
    private bool isQuitting;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void PlayClip(AudioClip clip, Transform FXtransform, float volume)
    {
        //spawn in GO
        AudioSource audiosource = Instantiate(soundFXobject, FXtransform.position, Quaternion.identity);

        //set audio clip

        audiosource.clip = clip;

        //set volume
        audiosource.volume = volume;

        //play sound
        audiosource.Play();

        float clip_length = clip.length;

        Destroy(audiosource.gameObject, clip_length);

        //destroy gameobject
    }

    public void PlaySetClip(int idx, Transform FXtransform, float volume)

    {
        if (isQuitting) return;


        AudioSource audiosource = Instantiate(soundFXobject, FXtransform.position, Quaternion.identity);
        if (idx == 0)
            audiosource.clip = key_pickup;
        else if(idx == 1)
            audiosource.clip = key_snap_interact;

        //set volume
        audiosource.volume = volume;

        //play sound
        audiosource.Play();

        float clip_length = audiosource.clip.length;

        Destroy(audiosource.gameObject, clip_length);
    }

}
