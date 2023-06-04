using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ensiklopedia : MonoBehaviour
{
    public GameObject[] encyclopediaPages;
    public Button previousButton;
    public Button nextButton;

    private int currentPageIndex = 0;
    private int totalPageCount;

    private void Start()
    {
        totalPageCount = encyclopediaPages.Length;

        previousButton.onClick.AddListener(ShowPreviousPage);
        nextButton.onClick.AddListener(ShowNextPage);

        LoadPage(currentPageIndex);
    }

    private void LoadPage(int pageIndex)
    {
        for (int i = 0; i < encyclopediaPages.Length; i++)
        {
            if (i == pageIndex)
                encyclopediaPages[i].SetActive(true);
            else
                encyclopediaPages[i].SetActive(false);
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
