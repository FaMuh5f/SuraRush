using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Eating")]
    [SerializeField] List<AudioClip> eatingClips; // List of eating audio clips
    [SerializeField] [Range(0f, 10f)] float eatingVolume = 10f;

    [Header("Dead")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0f, 10f)] float deathVolume = 10f;

    [Header("Power-up")]
    [SerializeField] AudioClip powerUpClip;
    [SerializeField] [Range(0f, 10f)] float powerUpVolume = 10f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayEatingClip()
    {
        if (eatingClips.Count > 0)
        {
            int randomIndex = Random.Range(0, eatingClips.Count);
            AudioClip clip = eatingClips[randomIndex];
            PlayClip(clip, eatingVolume);
        }
    }

    public void PlayDeathClip()
    {
        PlayClip(deathClip, deathVolume);
    }

    public void PlayPowerUpClip()
    {
        PlayClip(powerUpClip, powerUpVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;

            // Vector3 cameraPos = transform.position; // Assuming the AudioPlayer script is attached to the player game object
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
            // AudioSource.Play();
        }
    }
}
