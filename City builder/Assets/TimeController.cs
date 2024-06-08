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
        timeMultiplier = 1;
        previousMultiplier = 1;
        HighlightedButton10X.SetActive(false);
        HighlightedButton5X.SetActive(false);
        HighlightedButton1X.SetActive(true);
        Unpause();
    }

    public void FiveX()
    {
        timeMultiplier = 5;
        previousMultiplier = 5;
        HighlightedButton10X.SetActive(false);
        HighlightedButton5X.SetActive(true);
        HighlightedButton1X.SetActive(false);
        Unpause();
    }

    public void TenX()
    {
        timeMultiplier = 10;
        previousMultiplier = 10;
        HighlightedButton10X.SetActive(true);
        HighlightedButton5X.SetActive(false);
        HighlightedButton1X.SetActive(false);
        Unpause();
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
}
