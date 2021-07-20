using System;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using System.Globalization;
using UnityEngine;

public class ActivityLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder startTime, endTime, activityIntensity;
    
    public void Submit()
    {
        try
        { 
            //log base
            log.logType = Log.LogType.InsulinTaken;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.ParseExact(startTime.GetString(), "HH:mm", CultureInfo.InvariantCulture);
            //custom log
            log.endTime = DateTime.ParseExact(endTime.GetString(), "HH:mm", CultureInfo.InvariantCulture);
            if (activityIntensity.GetString() == "1") log.intensityOfActivity = Log.IntensityOfActivity.Low;
            if (activityIntensity.GetString() == "2") log.intensityOfActivity = Log.IntensityOfActivity.Medium;
            if (activityIntensity.GetString() == "3") log.intensityOfActivity = Log.IntensityOfActivity.High;

#if UNITY_EDITOR
            Debug.Log("Activity Submitted");
#else
            AndroidPlugin.ShowToast($"Activity Submitted\n{log.startTime}");
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