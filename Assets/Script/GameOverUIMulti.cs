using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUIMulti : MonoBehaviour
{
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI whoWin;
    [SerializeField] TextMeshProUGUI scoreText;
    Health healthPlayer1;
    Health2 healthPlayer2;


    private int score;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthPlayer1 = FindObjectOfType<Health>();
        healthPlayer2 = FindObjectOfType<Health2>();
    }

    void Start()
    {
        // score = scoreKeeper.GetScore();
    }

    void Update()
    {
        // string skorText = string.Format("Skor kamu: {0}", score);
        // scoreText.text = skorText;
        scoreText.text = scoreKeeper.GetScore().ToString();
        if(healthPlayer1.GetPlayer() == true)
        {
            whoWin.text = "Player 1 menang";
        }
        else if(healthPlayer2.GetPlayer() == true)
        {
            whoWin.text = "Player 2 menag";
        }
    }
}
