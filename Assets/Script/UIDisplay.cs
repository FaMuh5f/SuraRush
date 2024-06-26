using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    [SerializeField] TextMeshProUGUI healthText;

    [Header("Score")]
    [SerializeField] Slider scoreSlider;
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Speed")]
    [SerializeField] Slider speedSlider;
    [SerializeField] playerMovement playerMovement;
    [SerializeField] TextMeshProUGUI speedText;


    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        playerMovement = FindObjectOfType<playerMovement>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        scoreSlider.value = scoreKeeper.GetScore();
        healthSlider.value = playerHealth.GetHealth();
        speedSlider.value = playerMovement.getCurrentMoveSpeed();

        scoreText.text = scoreKeeper.GetScore().ToString();
        healthText.text = playerHealth.GetHealth().ToString();
        speedText.text = playerMovement.getCurrentMoveSpeed().ToString();
    }
}
