using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private GameObject particles;

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
        Faucet.OnToggleFaucet += Toggle;
    }

    private void Toggle(){
        particles.SetActive(!particles.activeSelf);
        Sound.Toggle(sound);
    }

    private void ResetAll(){
        if(Faucet.isOn){
            Toggle();
        }
    }
}
