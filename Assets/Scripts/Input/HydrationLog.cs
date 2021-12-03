using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using UnityEngine;

public class HydrationLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder waterDrank;
    [SerializeField] private Achievement dailyLogAchievement;
    
    public void Submit()
    {
        try
        {
            //log base
            log.logType = Log.LogType.Hydration;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.Now;
            //custom log
            log.glassesOfWater = Convert.ToInt32(waterDrank.GetString());
            
            BaseSave.SaveInList(BaseSave.LOGS, log);
            //SaveSystem.SaveUserData(log);
            
            AchievementsManager.CheckAddAchievement(dailyLogAchievement);
            
#if UNITY_EDITOR
            Debug.Log("Hydration Submitted");
#else
            AndroidPlugin.ShowToast($"Hydration Submitted\n{log.startTime}");
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