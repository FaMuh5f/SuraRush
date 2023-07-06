using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ensiklopedia : MonoBehaviour
{
    public EnsiPages[] encyclopediaPages;
    public Button previousButton;
    public Button nextButton;

    private int currentPageIndex = 0;
    private int totalPageCount;
    private int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        totalPageCount = encyclopediaPages.Length;

        previousButton.onClick.AddListener(ShowPreviousPage);
        nextButton.onClick.AddListener(ShowNextPage);

        LoadPage(currentPageIndex);
    }

    private void LoadPage(int pageIndex)
    {
        int selisih = 0;
        for (int i = 0; i < encyclopediaPages.Length; i++)
        {
            if (i == pageIndex)
            {
                encyclopediaPages[i].page.SetActive(true);

                // check if score is already achieved
                if (score >= encyclopediaPages[i].score)
                {
                    // deactive gameobject of blur
                    encyclopediaPages[i].uiBlur.gameObject.SetActive(false);
                }
                else
                {
                    // begin blur
                    encyclopediaPages[i].uiBlur.BeginBlur(1f);
                    // set text
                    selisih = encyclopediaPages[i].score - score;
                    encyclopediaPages[i].uiBlur.GetComponentInChildren<TextMeshProUGUI>().text = 
                    "SKOR ANDA BELUM CUKUP UNTUK MELIHAT ENSIKLOPEDIA INI!. Kamu butuh "+ selisih +"pt lagi...";
                }
            }
            else
            {
                encyclopediaPages[i].page.SetActive(false);
            }
        }
    }

    public void ShowPreviousPage()
    {
        currentPageIndex--;
        if (currentPageIndex < 0)
            currentPageIndex = 0;

        LoadPage(currentPageIndex);
    }

    public void ShowNextPage()
    {
        currentPageIndex++;
        if (currentPageIndex >= totalPageCount)
            currentPageIndex = totalPageCount - 1;

        LoadPage(currentPageIndex);
    }
}
