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

        //Sets it to winter;
        if (fMonths > 11 && fMonths < 3)
        {
            Spring = false;
            Summer = false;
            Fall = false;
            Winter = true;
        }
        
        //Sets it to summer
        if (fMonths > 5 && fMonths < 9)
        {
            Spring = false;
            Summer = true;
            Fall = false;
            Winter = false;
        }

        //Sets it to spring;
        if (fMonths > 2 && fMonths < 6)
        {
            Spring = false;
            Summer = false;
            Fall = false;
            Winter = true;
        }

        //Sets it to fall
        if (fMonths > 8 && fMonths < 12)
        {
            Spring = false;
            Summer = false;
            Fall = true;
            Winter = false;
        }

        MinutesTimeDisplay.text = (fMinutes.ToString("00"));
        HoursTimeDisplay.text = (fHours.ToString("00"));
    }
}
