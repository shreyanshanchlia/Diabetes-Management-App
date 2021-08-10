using System;
using System.Globalization;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using UnityEngine;

public class SugarReadingLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder sugarReading, startTime;
    
    public void Submit()
    {
        //try
        {
            //log base
            log.logType = Log.LogType.SugarReading;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.ParseExact(startTime.GetString(), "H:mm", CultureInfo.InvariantCulture);
            //custom log
            log.sugarReading = Convert.ToInt32(sugarReading.GetString());
            
            SaveSystem.SaveUserData(log);
            AchievementsManager.AchievementCurrentDayBloodSugarLogCountCheck();

#if UNITY_EDITOR
            Debug.Log("Sugar Reading Submitted");
#else
            AndroidPlugin.ShowToast($"Sugar Reading Submitted\n{log.startTime}");
#endif
        }
        //catch (Exception e)
        {
#if UNITY_EDITOR
            //throw e;
#else
            AndroidPlugin.ShowToast(e.Message);
#endif
        }
    }
}
