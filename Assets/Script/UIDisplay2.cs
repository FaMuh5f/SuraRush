using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay2 : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health2 playerHealth2;
    [SerializeField] TextMeshProUGUI healthText;

    [Header("Score")]
    [SerializeField] Slider scoreSlider;
    [SerializeField] ScoreKeeper2 scoreKeeper2;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Speed")]
    [SerializeField] Slider speedSlider;
    [SerializeField] playerMovement2 playerMovement2;
    [SerializeField] TextMeshProUGUI speedText;

    void Awake()
    {
        scoreKeeper2 = FindObjectOfType<ScoreKeeper2>();
        playerMovement2 = FindObjectOfType<playerMovement2>();

    }

    void Start()
    {
        healthSlider.maxValue = playerHealth2.GetHealth2();
    }

    void Update()
    {
        scoreSlider.value = scoreKeeper2.GetScore();
        healthSlider.value = playerHealth2.GetHealth2();
        speedSlider.value = playerMovement2.getCurrentMoveSpeed();

        scoreText.text = scoreKeeper2.GetScore().ToString();
        healthText.text = playerHealth2.GetHealth2().ToString();
        speedText.text = playerMovement2.getCurrentMoveSpeed().ToString();
    }
}
