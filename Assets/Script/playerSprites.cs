using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSprites : MonoBehaviour
{

    [SerializeField] ScoreKeeper scoreKeeper;

    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Animator animator;

    public Sprite bayiSprite;
    public Sprite remajaSprite;
    public Sprite dewasaSprite;
    public Sprite dewasaMatangSprite;
    public Sprite megalodonSprite;

    private int score;

    private void Start()
    {

        // Initialize the sprite renderer and set the initial sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSpriteBasedOnScore();
    }

    private void Update()
    {
        // Update the sprite based on the new score
        SetSpriteBasedOnScore();

        score = scoreKeeper.GetScore();
        Debug.Log(score);
    }

    private void SetSpriteBasedOnScore()
    {
        if (score >= 7000)
        {
            // spriteRenderer.sprite = megalodonSprite; // Set the Megamouth sprite for score >= 7000
            Debug.Log("megalodonSprite");
            gameObject.tag = "Megalodon";
            animator.SetBool("isDewasaMatang",false);
            animator.SetBool("Megalodon",true);
        }
        else if (score >= 5000)
        {
            // spriteRenderer.sprite = dewasaMatangSprite; // Set the Dewasa-Matang sprite for score >= 5000
            Debug.Log("dewasaMatangSprite");
            gameObject.tag = "DewasaMatang";
            animator.SetBool("isDewasa",false);
            animator.SetBool("isDewasaMatang",true);
        }
        else if (score >= 3000)
        {
            // spriteRenderer.sprite = dewasaSprite; // Set the Dewasa sprite for score >= 3000
            Debug.Log("dewasaSprite");
            gameObject.tag = "Dewasa";
            animator.SetBool("isRemaja",false);
            animator.SetBool("isDewasa",true);
        }
        else if (score >= 1000)
        {
            // spriteRenderer.sprite = remajaSprite; // Set the Remaja sprite for score >= 1000
            Debug.Log("remajaSprite");
            gameObject.tag = "Remaja";
            // animator.SetBool("isBayi",false);
            animator.SetBool("isRemaja",true);
        }
        else
        {
            // spriteRenderer.sprite = bayiSprite; // Set the Bayi sprite for score < 1000
            Debug.Log("bayiSprite");
            gameObject.tag = "Bayi";
            // animator.SetBool("isBayi",true);
        }
    }
}
