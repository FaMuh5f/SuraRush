using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;

    private int score;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        // score = scoreKeeper.GetScore();
    }

    void Update()
    {
        // string skorText = string.Format("Skor kamu: {0}", score);
        // scoreText.text = skorText;
        scoreText.text = "Skor kamu adalah:\n" + scoreKeeper.GetScore();

        // save to playerprefs if score is higher than previous score
        if (scoreKeeper.GetScore() > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", scoreKeeper.GetScore());
        }
    }
}
