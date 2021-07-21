using System;
using System.Globalization;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using UnityEngine;

public class MealLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder mealTaken, startTime;
    
    public void Submit()
    {
        try
        {
            //log base
            log.logType = Log.LogType.Meal;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.ParseExact(startTime.GetString(), "H:mm", CultureInfo.InvariantCulture);
            //custom log
            log.food = mealTaken.GetString();

            SaveSystem.SaveUserData(log);
#if UNITY_EDITOR
            Debug.Log("Meal Submitted");
#else
            AndroidPlugin.ShowToast($"Meal Submitted\n{log.startTime}");
#endif
        }
        catch (Exception e)
        {
#if UNITY_EDITOR
            Debug.Log(e.Message);
#else
            AndroidPlugin.ShowToast(e.Message);
#endif
        }
    }
}