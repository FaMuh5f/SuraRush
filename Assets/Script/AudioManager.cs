using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance

    public AudioSource backgroundMusic; // Background music audio source

    private SfxManager sfxManager; // Reference to the SfxManager script

    private void Awake()
    {
        // Create a singleton instance of the AudioManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Make sure the AudioManager object persists across scenes
        DontDestroyOnLoad(gameObject);

        // Get a reference to the SfxManager script
        sfxManager = FindObjectOfType<SfxManager>();
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        // Set the background music clip and play it
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }

    public void StopBackgroundMusic()
    {
        // Stop the background music
        backgroundMusic.Stop();
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        // Set the volume of the background music
        backgroundMusic.volume = volume;
    }

    public float GetBackgroundMusicVolume()
    {
        // Return the volume of the background music
        return backgroundMusic.volume;
    }

    public void PlaySFX(AudioClip clip)
    {
        // Use the SfxManager to play the sound effect
        sfxManager.PlaySFX(clip);
    }

    public void StopSFX()
    {
        // Use the SfxManager to stop the sound effect
        sfxManager.StopSFX();
    }

    public void SetSFXVolume(float volume)
    {
        // Use the SfxManager to set the volume of the sound effect
        sfxManager.SetSFXVolume(volume);
    }

    public float GetSFXVolume()
    {
        // Use the SfxManager to return the volume of the sound effect
        return sfxManager.GetSFXVolume();
    }
}
