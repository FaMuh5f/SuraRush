using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverSfx : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSound;
    private Button button;

    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play the hover sound effect only if the button is interactable and the hover sound is assigned
        if (button.interactable && hoverSound != null)
        {
            AudioManager.instance.PlaySFX(hoverSound);
        }
    }
}
