using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSprites : MonoBehaviour
{

    [SerializeField] playerMovement playerMovement;
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] Slider scoreSlider;
    ParticleSystemRenderer eatEffect;

    public Sprite bayiSprite;
    public Sprite remajaSprite;
    public Sprite dewasaSprite;
    public Sprite dewasaMatangSprite;
    public Sprite megalodonSprite;

    private int score;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        // Initialize the sprite renderer and set the initial sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        eatEffect = GetComponent<ParticleSystemRenderer>();
    }

    private void Start()
    {
        SetSpriteBasedOnScore();
    }

    private void Update()
    {
        // Update the sprite based on the new score
        SetSpriteBasedOnScore();

        score = scoreKeeper.GetScore();
        // Debug.Log(score);
    }

    private void SetSpriteBasedOnScore()
    {
        if (score >= 7000)
        {
            // spriteRenderer.sprite = megalodonSprite; // Set the Megamouth sprite for score >= 7000
            // Debug.Log("megalodonSprite");
            gameObject.tag = "Megalodon";
            animator.SetBool("isDewasaMatang",false);
            animator.SetBool("isMegalodon",true);
            scoreSlider.maxValue = 999999;
            playerMovement.setMovemmentSpeed(14);
            GetComponent<BoxCollider2D>().offset = new Vector2(3.8f, -0.5f);
            eatEffect.pivot = new Vector2(3.8f, -0.5f);
        }
        else if (score >= 5000)
        {
            // spriteRenderer.sprite = dewasaMatangSprite; // Set the Dewasa-Matang sprite for score >= 5000
            // Debug.Log("dewasaMatangSprite");
            gameObject.tag = "DewasaMatang";
            animator.SetBool("isDewasa",false);
            animator.SetBool("isDewasaMatang",true);
            scoreSlider.maxValue = 7000;
            playerMovement.setMovemmentSpeed(12);
            GetComponent<BoxCollider2D>().offset = new Vector2(2.4f, -0.5f);
            eatEffect.pivot = new Vector2(2.4f, -0.5f);
        }
        else if (score >= 3000)
        {
            // spriteRenderer.sprite = dewasaSprite; // Set the Dewasa sprite for score >= 3000
            // Debug.Log("dewasaSprite");
            gameObject.tag = "Dewasa";
            animator.SetBool("isRemaja",false);
            animator.SetBool("isDewasa",true);
            scoreSlider.maxValue = 5000;
            playerMovement.setMovemmentSpeed(10);
            GetComponent<BoxCollider2D>().offset = new Vector2(1.65f, 0f);
            eatEffect.pivot = new Vector2(1.65f, 0f);
        }
        else if (score >= 1000)
        {
            // spriteRenderer.sprite = remajaSprite; // Set the Remaja sprite for score >= 1000
            // Debug.Log("remajaSprite");
            gameObject.tag = "Remaja";
            // animator.SetBool("isBayi",false);
            animator.SetBool("isRemaja",true);
            scoreSlider.maxValue = 3000;
            playerMovement.setMovemmentSpeed(8);
            GetComponent<BoxCollider2D>().offset = new Vector2(1.25f, 0f);
            eatEffect.pivot = new Vector2(1.25f, 0f);
        }
        else
        {
            // spriteRenderer.sprite = bayiSprite; // Set the Bayi sprite for score < 1000
            // Debug.Log("bayiSprite");
            gameObject.tag = "Bayi";
            // animator.SetBool("isBayi",true);
            scoreSlider.maxValue = 1000;
            playerMovement.setMovemmentSpeed(5);
            GetComponent<BoxCollider2D>().offset = new Vector2(1f, 0f);
            eatEffect.pivot = new Vector2(1f, 0f);
        }
    }
}
