using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static int timeMultiplier;
    public TextMeshProUGUI multiplierText;

    private void Start()
    {
        multiplierText = GameObject.Find("multiplierDisplayText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        multiplierText.text = ("x" + timeMultiplier.ToString());
    }

    public void TimeControllerButtonMore()
    {
        if (timeMultiplier == 0)
        {
            timeMultiplier = 1;
        }else if (timeMultiplier == 1)
        {
            timeMultiplier = 2;
        }else if (timeMultiplier == 2)
        {
            timeMultiplier = 5;
        }else if (timeMultiplier == 5)
        {
            timeMultiplier = 1;
        }
    }

    public void Pause()
    {
        timeMultiplier = 0;
    }

    public void TimeControllerButtonLess()
    {
        if (timeMultiplier == 0)
        {
            timeMultiplier = 5;
        }
        else if (timeMultiplier == 1)
        {
            timeMultiplier = 5;
        }
        else if (timeMultiplier == 2)
        {
            timeMultiplier = 1;
        }
        else if (timeMultiplier == 5)
        {
            timeMultiplier = 2;
        }
    }
}
