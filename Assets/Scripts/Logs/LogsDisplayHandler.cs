using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
// ReSharper disable once RedundantUsingDirective
using FantomLib;

public class LogsDisplayHandler : MonoBehaviour
{
    public bool showLogs = true;
    [SerializeField] private Transform logsHolder;
    [SerializeField] private GameObject logDisplayPrefab;
    [SerializeField] private StringHolder startDateString, endDateString;

    [HideInInspector] public DateTime startDate, endDate;
    private bool useDateFilter = false;
    List<Log> logs;

    private void Start()
    {
        if (showLogs)
        {
            ShowLogs();
        }
    }

    public void ShowLogs()
    {
        LoadLogs();
        DeleteExisting();
        SetDateFilter();
        DisplayLogs();
    }

    void SetDateFilter()
    {
        try
        {
            startDate = DateTime.ParseExact(startDateString.GetString(), "yyyy/M/d", CultureInfo.InvariantCulture);
            endDate = DateTime.ParseExact(endDateString.GetString(), "yyyy/M/d", CultureInfo.InvariantCulture);
            useDateFilter = true;
        }
        catch (Exception e)
        {
            useDateFilter = false;
            
#if UNITY_EDITOR
            Debug.Log(e.Message + " Loading All");
#else
            AndroidPlugin.ShowToast(e.Message);
#endif
        }
    }
    
    void DeleteExisting()
    {
        int childs = logsHolder.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(logsHolder.GetChild(i).gameObject);
        }
    }

    public void LoadLogs()
    {
        //logs = SaveSystem.GetUserData().logs;
        logs = BaseSave.Load(BaseSave.LOGS, new List<Log>());
        logs = logs.OrderBy(t => t.startTime).ToList();
    }

    public List<Log> GetLogsFiltered()
    {
        List<Log> filteredLogList = new List<Log>();
        foreach (Log log in logs)
        {
            if (startDate.Date <= log.startTime && log.startTime <= endDate.Date.AddDays(1).AddSeconds(-1))
            {
                filteredLogList.Add(log);
            }
        }
        
        return filteredLogList;
    }

    void DisplayLogs()
    {
        foreach (Log log in logs)
        {
            if (!useDateFilter || (startDate.Date <= log.startTime && log.startTime <= endDate.Date.AddDays(1).AddSeconds(-1)))
            {
                GameObject currentLog = Instantiate(logDisplayPrefab, logsHolder);
                currentLog.GetComponent<LogHolder>().SetLog(log);
            }
        }
    }
}
