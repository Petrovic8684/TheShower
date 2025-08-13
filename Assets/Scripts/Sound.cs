using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static void Play(AudioSource sound){
        if(!sound.isPlaying){
            sound.Play();
        }
    }

    public static void Stop(AudioSource sound){
        if(sound.isPlaying){
            sound.Stop();
        }
    }

    public static void Toggle(AudioSource sound){
        if(sound.isPlaying){
            sound.Stop();
        }
        else{
            sound.Play();
        }
    }

    public static void PlayOneShot(AudioSource sound){
        sound.PlayOneShot(sound.clip);
    }
}
