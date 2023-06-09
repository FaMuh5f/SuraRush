using UnityEngine;
using UnityEngine.UI;

public class ButtonSfx : MonoBehaviour
{
    public Button button;
    public AudioClip buttonClickClip;
    public AudioClip buttonHoverClip;

    private void Start()
    {
        // Subscribe to the button's onClick event
        button.onClick.AddListener(PlayButtonClickSFX);

        // Add the ButtonHoverSfx script to handle hover sound effect
        ButtonHoverSfx buttonHoverSFX = button.gameObject.AddComponent<ButtonHoverSfx>();
        buttonHoverSFX.hoverSound = buttonHoverClip;
    }

    private void PlayButtonClickSFX()
    {
        // Play the button click sound effect
        AudioManager.instance.PlaySFX(buttonClickClip);
    }
}
