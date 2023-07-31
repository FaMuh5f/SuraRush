using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUIMulti : MonoBehaviour
{
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] ScoreKeeper2 scoreKeeper2;
    [SerializeField] winTracker winTracker;
    [SerializeField] TextMeshProUGUI whoWin;
    [SerializeField] TextMeshProUGUI scoreText;
    Health healthPlayer;
    Health2 healthPlayer2;


    private int score;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper2 = FindObjectOfType<ScoreKeeper2>();
        healthPlayer = FindObjectOfType<Health>();
        healthPlayer2 = FindObjectOfType<Health2>();
        winTracker = FindObjectOfType<winTracker>();
    }

    void Start()
    {
        // score = scoreKeeper.GetScore();
    }

    void Update()
    {
        // string skorText = string.Format("Skor kamu: {0}", score);
        // scoreText.text = skorText;
        
        if(winTracker.getWhoWin() == true)
        {
            whoWin.text = "Player 1 menang";
            scoreText.text = scoreKeeper.GetScore().ToString();
        }
        else if(winTracker.getWhoWin() == false)
        {
            whoWin.text = "Player 2 menang";
            scoreText.text = scoreKeeper2.GetScore().ToString();
        }
    }
}
