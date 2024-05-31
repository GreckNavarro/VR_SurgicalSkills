using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

[CreateAssetMenu(fileName = "SoundsSO", menuName = "SoundsSO/SoundsSO", order = 0)]
public class SoundsSO : ScriptableObject
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string channelVolume;
    [SerializeField] private float currentVolume;
    //private bool ismuted = true;
    private void OnEnable()
    {
    }

    public void UpdateVolume(Slider slider)
    {
        currentVolume = slider.value;
        mixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
        SavePreference(); 
    }

    private void SavePreference()
    {
        PlayerPrefs.SetFloat(channelVolume, currentVolume);
        PlayerPrefs.Save();
    }

    public void LoadPreference(Slider slider)
    {
        slider.value = currentVolume;
        currentVolume = PlayerPrefs.GetFloat(channelVolume, currentVolume);
        mixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
    }
    //public void MuteVolume()
    //{
    //    if (ismuted == true)
    //    {
    //        mixer.SetFloat(channelVolume, Mathf.Log10(-80) * 20f);
    //        ismuted = false;
    //    }
    //    else
    //    {
    //        mixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
    //        ismuted = true;
    //    }
    //}

}
