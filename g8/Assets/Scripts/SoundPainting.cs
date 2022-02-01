using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPainting : Painting
{
    public AudioClip clip;
    public AudioSource source;
    bool started = false;

    public override void Execute()
    {
        base.Execute();
        if(!started) 
        {
            source.clip = clip;
            source.Play();      
            started = true;
        }
        else{
            source.UnPause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        source.Pause();
    }

    public void SetAudioClip(AudioClip ac){
        clip = ac;
    }
}
