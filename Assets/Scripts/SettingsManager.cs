using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer; // A reference to the game's audio mixer
    [SerializeField] private Slider audioSlider; // A reference to the audio slider ( UI element)

    // Sets the initial slider positions on menu load
    private void Start(){
        float soundValue = PlayerPrefs.GetFloat("Volume", 0.9783473f);
        soundValue = Mathf.Exp(soundValue/20);
        audioSlider.value = soundValue;
    }

    // Updates the volume on slider drag
    public void SetVolume(float volume){
        float value = Mathf.Log(volume) * 20;
        PlayerPrefs.SetFloat("Volume", value);
        mixer.SetFloat("musicVol", value);
    }
}
