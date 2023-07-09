using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePlayTime : MonoBehaviour
{
    private float totalPlaytime;
    private bool isPlaying;

    public TextMeshProUGUI playtimeText; // Reference to the Text component on the Canvas

    private void Start()
    {
        totalPlaytime = 0f;
        isPlaying = true;
        // Clear the stored playtime in PlayerPrefs
        PlayerPrefs.DeleteKey("TotalPlaytime");
    }

    private void Update()
    {
        if (isPlaying)
        {
            totalPlaytime += Time.deltaTime;
            UpdatePlaytimeText();
        }
    }

    private void OnApplicationQuit()
    {
        isPlaying = false;
        // Save the total playtime in PlayerPrefs
        PlayerPrefs.SetFloat("TotalPlaytime", totalPlaytime);
        PlayerPrefs.Save();
    }

    private void UpdatePlaytimeText()
    {
        int minutes = Mathf.FloorToInt(totalPlaytime / 60f);
        int seconds = Mathf.FloorToInt(totalPlaytime % 60f);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        playtimeText.text = timeText;
    }
}
