using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DailyLogActivity : MonoBehaviour
{
    protected int sugarCount, insulinCount, activityCount, mealCount, sleepCount, hydrationCount;

    private void Start()
    {
        SetCounters();
    }

    protected void SetCounters()
    {
        LogsDisplayHandler logsDisplayHandler = gameObject.AddComponent<LogsDisplayHandler>();
        logsDisplayHandler.showLogs = false;
        logsDisplayHandler.startDate = DateTime.Today;
        logsDisplayHandler.endDate = DateTime.Today;
        
        logsDisplayHandler.LoadLogs();
        
        List<Log> logs = logsDisplayHandler.GetLogsFiltered();

        sugarCount = logs.Where(t => t.logType == Log.LogType.SugarReading).ToList().Count;
        insulinCount = logs.Where(t => t.logType == Log.LogType.InsulinTaken).ToList().Count;
        activityCount = logs.Where(t => t.logType == Log.LogType.Activity).ToList().Count;
        mealCount = logs.Where(t => t.logType == Log.LogType.Meal).ToList().Count;
        sleepCount = logs.Where(t => t.logType == Log.LogType.Sleep).ToList().Count;
        hydrationCount = logs.Where(t => t.logType == Log.LogType.Hydration).ToList().Count;
        
        Destroy(logsDisplayHandler);
    }
}
