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
    private const string VolumePrefKey = "VolumePref";
    //private bool ismuted = true;
    [SerializeField] private float defaultVolume = 1f;
    private void OnEnable()
    {
        LoadPreference();
    }

    public void UpdateVolume(Slider slider)
    {
        currentVolume = slider.value;
        mixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
        SavePreference(); 
    }

    private void SavePreference()
    {
        PlayerPrefs.SetFloat(VolumePrefKey, currentVolume);
        PlayerPrefs.Save();
    }

    private void LoadPreference()
    {
        currentVolume = PlayerPrefs.GetFloat(VolumePrefKey, defaultVolume);
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
