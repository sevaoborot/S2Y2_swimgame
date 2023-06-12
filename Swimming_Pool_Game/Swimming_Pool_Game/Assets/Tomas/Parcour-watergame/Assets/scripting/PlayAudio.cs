using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume = 0.5f;
    AudioSource audio;
    public bool alreadyPlayed = false;
   
    void Start()
    {
     audio = GetComponent<AudioSource>();
    }

void OnTriggerEnter ()
{
    if (!alreadyPlayed)
    {
     // GetComponent<AudioSource>().Play();
     audio.PlayOneShot(SoundToPlay, Volume);
     alreadyPlayed = true;
    }
}
    
 
}
