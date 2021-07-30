using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class DailyLogActivityDisplay : DailyLogActivity
{
    [SerializeField] private float updateRate = 2f;

    [Header("Counter Text Settings")]
    [SerializeField] private string prefixText, suffixText;

    [Header("Text References")] 
    [SerializeField] private TextMeshProUGUI sugarCounterText;

    [SerializeField] private TextMeshProUGUI insulinCounterText;
    [SerializeField] private TextMeshProUGUI activityCounterText;
    [SerializeField] private TextMeshProUGUI mealCounterText;
    [SerializeField] private TextMeshProUGUI sleepCounterText;
    [SerializeField] private TextMeshProUGUI hydrationCounterText;

    private void Start()
    {
        InvokeRepeating(nameof(DisplayMeasurementCounters), 0, updateRate);
    }
    void DisplayMeasurementCounters()
    {
        SetCounters();
        
        sugarCounterText.text = $"{prefixText}{sugarCount}{suffixText}";
        insulinCounterText.text = $"{prefixText}{insulinCount}{suffixText}";
        activityCounterText.text = $"{prefixText}{activityCount}{suffixText}";
        mealCounterText.text = $"{prefixText}{mealCount}{suffixText}";
        sleepCounterText.text = $"{prefixText}{sleepCount}{suffixText}";
        hydrationCounterText.text = $"{prefixText}{hydrationCount}{suffixText}";
    }
}
