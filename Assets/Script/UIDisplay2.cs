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

    void Awake()
    {
        scoreKeeper2 = FindObjectOfType<ScoreKeeper2>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth2.GetHealth2();
    }

    void Update()
    {
        scoreSlider.value = scoreKeeper2.GetScore2();
        healthSlider.value = playerHealth2.GetHealth2();

        scoreText.text = scoreKeeper2.GetScore2().ToString();
        healthText.text = playerHealth2.GetHealth2().ToString();
    }
}
