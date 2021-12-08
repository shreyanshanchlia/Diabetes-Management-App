using System;
using System.Collections.Generic;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class SleepLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder startTime, endTime;
    [SerializeField] private Achievement dailyLogAchievement;
    
    public void Submit()
    {
        try
        { 
            //log base
            log.logType = Log.LogType.Sleep;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.ParseExact(startTime.GetString(), "H:mm", CultureInfo.InvariantCulture);
            //custom log
            log.endTime = DateTime.ParseExact(endTime.GetString(), "H:mm", CultureInfo.InvariantCulture);

            //SaveSystem.SaveUserData(log);
            BaseSave.SaveInList(BaseSave.LOGS, log);

            AchievementsManager.CheckAddAchievement(dailyLogAchievement);
            
#if UNITY_EDITOR
            Debug.Log("Sleep Submitted");
#else
            AndroidPlugin.ShowToast($"Sleep Submitted\n{log.startTime}");
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