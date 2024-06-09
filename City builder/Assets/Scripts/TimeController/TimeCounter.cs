using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float fHours;
    public float fDays;
    public float fSeconds;
    public float fMinutes;
    public float fMonths;
    public float fYears;
    public bool Spring;
    public bool Summer;
    public bool Fall;
    public bool Winter;

    TextMeshProUGUI DayText;
    TextMeshProUGUI MonthText;
    TextMeshProUGUI YearText;

    TextMeshProUGUI MinutesTimeDisplay;
    TextMeshProUGUI HoursTimeDisplay;


    private void Start()
    {
        DayText = GameObject.Find("DayText").GetComponent<TextMeshProUGUI>();
        MonthText = GameObject.Find("MonthText").GetComponent<TextMeshProUGUI>();
        YearText = GameObject.Find("YearText").GetComponent<TextMeshProUGUI>();

        fYears = Random.Range(2000, 2050);
        fMonths = Random.Range(1, 12);
        fDays = Random.Range(1, 30);

        MinutesTimeDisplay = GameObject.Find("TimeDisplayText").GetComponent<TextMeshProUGUI>();
        HoursTimeDisplay = GameObject.Find("HourDisplayText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        fSeconds += 1 * 144 * (Time.deltaTime * TimeController.timeMultiplier);
        if (fSeconds >= 60)
        {
            fSeconds = 0; fMinutes += 1;
        }
        if (fMinutes >= 60)
        {
            fMinutes = 0; fHours += 1;
        }
        if (fHours >= 24)
        {
            fHours = 0; fDays += 1;
        }
        if (fDays > 30) 
        {
            fDays = 0; fMonths += 1;
        }
        if (fMonths > 12)
        {
            fMonths = 0; fYears += 1;
        }

        DayText.text = fDays.ToString();
        MonthText.text = fMonths.ToString();
        YearText.text = fYears.ToString();

        Spring = (fMonths >= 3 && fMonths <= 5);
        Winter = (fMonths == 12 || fMonths == 1 || fMonths == 2);
        Summer = (fMonths >= 6 && fMonths <= 8);
        Fall = (fMonths >= 9 && fMonths <= 11);

        MinutesTimeDisplay.text = (fMinutes.ToString("00"));
        HoursTimeDisplay.text = (fHours.ToString("00"));
    }
}
