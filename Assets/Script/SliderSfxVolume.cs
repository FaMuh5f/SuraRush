using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSfxVolume : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        // Set the slider value to the current volume from AudioManager
        slider.value = AudioManager.instance.GetSFXVolume();

        // Add a listener to the slider to detect when the value changes
        slider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float value)
    {
        // Update the volume in AudioManager
        AudioManager.instance.SetSFXVolume(value);
    }
}
