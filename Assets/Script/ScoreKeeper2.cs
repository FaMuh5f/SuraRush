using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper2 : MonoBehaviour
{
    int score2;

    static ScoreKeeper2 instance;
    
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score2;
    }

    public void ModifyScore(int value)
    {
        score2 += value;
        Mathf.Clamp(score2, 0, int.MaxValue);
        // Debug.Log(score2);
    }

    public void ResetScore()
    {
        score2 = 0;
    }
}
