using System;
using System.Collections.Generic;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class InsulinTakenLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder startTime, insulinQuantity, insulinType;
    [SerializeField] private Achievement dailyLogAchievement;
    
    public void Submit()
    {
        try
        { 
            //log base
            log.logType = Log.LogType.InsulinTaken;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.ParseExact(startTime.GetString(), "H:mm", CultureInfo.InvariantCulture);
            //custom log
            log.insulinQuantity = Convert.ToInt32(insulinQuantity.GetString());
            if (insulinType.GetString() == "1") log.typeOfInsulinTaken = Log.TypeOfInsulin.Bolus;
            if (insulinType.GetString() == "2") log.typeOfInsulinTaken = Log.TypeOfInsulin.Basil;
            
            //SaveSystem.SaveUserData(log);
            BaseSave.SaveInList(BaseSave.LOGS, log);
            
            AchievementsManager.CheckAddAchievement(dailyLogAchievement);
            
#if UNITY_EDITOR
            Debug.Log("Insulin Taken Submitted");
#else
            AndroidPlugin.ShowToast($"Insulin Taken Submitted\n{log.startTime}");
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
