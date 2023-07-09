using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSprites2 : MonoBehaviour
{

    [SerializeField] ScoreKeeper2 scoreKeeper2;
    [SerializeField] SpriteRenderer spriteRenderer2;
    // [SerializeField] Animator animator2;
    [SerializeField] Slider scoreSlider2;

    public Sprite bayiSprite2;
    public Sprite remajaSprite2;
    public Sprite dewasaSprite2;
    public Sprite dewasaMatangSprite2;
    public Sprite megalodonSprite2;

    private int score2;

    void Awake()
    {
        scoreKeeper2 = FindObjectOfType<ScoreKeeper2>();
        // Initialize the sprite renderer and set the initial sprite
        spriteRenderer2 = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetSpriteBasedOnScore2();
    }

    private void Update()
    {
        // Update the sprite based on the new score2
        SetSpriteBasedOnScore2();

        score2 = scoreKeeper2.GetScore2();
        // Debug.Log(score2);
    }

    private void SetSpriteBasedOnScore2()
    {
        if (score2 >= 7000)
        {
            spriteRenderer2.sprite = megalodonSprite2; // Set the Megamouth sprite for score2 >= 7000
            // Debug.Log("megalodonSprite2");
            gameObject.tag = "Titanochampsa";
            // animator2.SetBool("isDewasaMatang",false);
            // animator2.SetBool("isMegalodon",true);
            scoreSlider2.maxValue = 999999;
        }
        else if (score2 >= 5000)
        {
            spriteRenderer2.sprite = dewasaMatangSprite2; // Set the Dewasa-Matang sprite for score2 >= 5000
            // Debug.Log("dewasaMatangSprite2");
            gameObject.tag = "DewasaMatang2";
            // animator2.SetBool("isDewasa",false);
            // animator2.SetBool("isDewasaMatang",true);
            scoreSlider2.maxValue = 7000;
        }
        else if (score2 >= 3000)
        {
            spriteRenderer2.sprite = dewasaSprite2; // Set the Dewasa sprite for score2 >= 3000
            // Debug.Log("dewasaSprite2");
            gameObject.tag = "Dewasa2";
            // animator2.SetBool("isRemaja",false);
            // animator2.SetBool("isDewasa",true);
            scoreSlider2.maxValue = 5000;
        }
        else if (score2 >= 1000)
        {
            spriteRenderer2.sprite = remajaSprite2; // Set the Remaja sprite for score2 >= 1000
            // Debug.Log("remajaSprite2");
            gameObject.tag = "Remaja2";
            // animator2.SetBool("isBayi",false);
            // animator2.SetBool("isRemaja",true);
            scoreSlider2.maxValue = 3000;
        }
        else
        {
            spriteRenderer2.sprite = bayiSprite2; // Set the Bayi sprite for score2 < 1000
            // Debug.Log("bayiSprite2");
            gameObject.tag = "Bayi2";
            // animator2.SetBool("isBayi",true);
            scoreSlider2.maxValue = 1000;
        }
    }
}
