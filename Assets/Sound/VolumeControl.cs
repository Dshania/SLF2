using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMix;

    public void SetMasterVol(float sliderValue)
    {
        audioMix.SetFloat("Master", Mathf.Log10(sliderValue) *20);
    }

    public void SetMusicVol(float sliderValue)
    {
        audioMix.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXVol(float sliderValue)
    {
        audioMix.SetFloat("Sound", Mathf.Log10(sliderValue) * 20);
    }
}