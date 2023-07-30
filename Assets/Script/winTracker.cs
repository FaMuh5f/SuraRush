using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winTracker : MonoBehaviour
{
    static winTracker instance;
    public bool whoWin = false;
    Health health;
    Health2 health2;
    
    void Awake()
    {
        ManageSingleton();
        health = FindObjectOfType<Health>();
        health2 = FindObjectOfType<Health2>();
    }

    private void Update() {
        if(health.GetPlayer() == true && health2.GetPlayer() == false)
        {
            whoWin = true;
        }
        else if(health.GetPlayer() == false && health2.GetPlayer() == true)
        {
            whoWin = false;
        }
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

    public bool getWhoWin(){
        return whoWin;
    }

    public void resetWin(){
        whoWin = false;
    }
}
