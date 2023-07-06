using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSfxVolume : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        // Add a listener to the slider to detect when the value changes
        slider.onValueChanged.AddListener(UpdateVolume);

        // get old value from playerprefs if set
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            slider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            // Set the slider value to the current volume from AudioManager
            slider.value = AudioManager.instance.GetSFXVolume();
        }
    }

    private void UpdateVolume(float value)
    {
        // Update the volume in AudioManager
        AudioManager.instance.SetSFXVolume(value);

        // save to playerprefs
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}
