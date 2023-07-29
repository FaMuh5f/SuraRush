using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    // text mesh pro
    private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        highScoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();        
    }
}
