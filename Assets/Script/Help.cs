using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public GameObject[] helpPages;

    public void ShowPage(int index)
    {
        for (int i = 0; i < helpPages.Length; i++)
        {
            if (i == index)
                helpPages[i].SetActive(true);
            else
                helpPages[i].SetActive(false);
        }
    }
    
}
