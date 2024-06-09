using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static int timeMultiplier;
    public int previousMultiplier;

    GameObject HighlightedButton1X;
    GameObject HighlightedButton5X;
    GameObject HighlightedButton10X;

    GameObject PauseButton;
    GameObject UnpauseButton;

    public TextMeshProUGUI DayText;
    public TextMeshProUGUI MonthText;
    public TextMeshProUGUI YearText;

    private void Start()
    {
        HighlightedButton1X = GameObject.Find("HighlightedButton1");
        HighlightedButton5X = GameObject.Find("HighlightedButton2");
        HighlightedButton10X = GameObject.Find("HighlightedButton3");
        UnpauseButton = GameObject.Find("UnpauseButtonHolder");
        PauseButton = GameObject.Find("PauseButtonHolder");

        UnpauseButton.SetActive(false);
        HighlightedButton10X.SetActive(false);
        HighlightedButton5X.SetActive(false);
        HighlightedButton1X.SetActive(true);
        timeMultiplier = 1;
    }


    //TimeButtons
    public void OneX()
    {
        SetMultiplier(1);
    }

    public void FiveX()
    {
        SetMultiplier(5);
    }

    public void TenX()
    {
        SetMultiplier(10);
    }
    

    public void Pause()
    {
        timeMultiplier = 0;
        PauseButton.SetActive(false);
        UnpauseButton.SetActive(true);
    }

    public void Unpause()
    {
        timeMultiplier = previousMultiplier;
        PauseButton.SetActive(true);
        UnpauseButton.SetActive(false);
    }

    void SetMultiplier(int multiplier)
    {
        timeMultiplier = multiplier;
        previousMultiplier = multiplier;

        HighlightedButton1X.SetActive(multiplier == 1);
        HighlightedButton5X.SetActive(multiplier == 5);
        HighlightedButton10X.SetActive(multiplier == 10);
        UnpauseButton.SetActive(false);
        PauseButton.SetActive(true);
    }
}
