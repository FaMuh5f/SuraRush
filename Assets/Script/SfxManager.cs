using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager instance; // Singleton instance

    public AudioSource soundEffect; // Sound effect audio source
    private void Awake()
    {
        // Create a singleton instance of the SfxManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        // Play the sound effect clip
        soundEffect.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        // Stop the sound effect
        soundEffect.Stop();
    }

    public void SetSFXVolume(float volume)
    {
        // Set the volume of the sound effect
        soundEffect.volume = volume;
    }

    public float GetSFXVolume()
    {
        // Return the volume of the sound effect
        return soundEffect.volume;
        ;
    }
}
