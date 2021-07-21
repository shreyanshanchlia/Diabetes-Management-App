using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class LogsDisplayHandler : MonoBehaviour
{
    [SerializeField] private Transform logsHolder;
    [SerializeField] private GameObject logDisplayPrefab;
    [SerializeField] private StringHolder startDateString, endDateString;

    private DateTime startDate, endDate;
    private bool useDateFilter = false;
    List<Log> logs;

    private void Start()
    {
        ShowLogs();
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
            startDate = DateTime.ParseExact(startDateString.GetString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            endDate = DateTime.ParseExact(endDateString.GetString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            useDateFilter = true;
        }
        catch (Exception e)
        {
            useDateFilter = false;
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
    
    void LoadLogs()
    {
        logs = SaveSystem.GetUserData().logs;
        logs = logs.OrderBy(t => t.startTime).ToList();
    }

    void DisplayLogs()
    {
        foreach (Log log in logs)
        {
            if (!useDateFilter || (startDate < log.startTime && log.endTime > endDate))
            {
                GameObject currentLog = Instantiate(logDisplayPrefab, logsHolder);
                currentLog.GetComponent<LogHolder>().SetLog(log);
            }
        }
    }
}
