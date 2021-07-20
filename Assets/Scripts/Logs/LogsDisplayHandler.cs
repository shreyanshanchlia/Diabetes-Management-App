using System.Collections.Generic;
using UnityEngine;

public class LogsDisplayHandler : MonoBehaviour
{
    [SerializeField] private Transform logsHolder;
    [SerializeField] private GameObject logDisplayPrefab; 
    List<Log> logs;

    public void ShowLogs()
    {
        LoadLogs();
        DeleteExisting();
        DisplayLogs();
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
    }

    void DisplayLogs()
    {
        foreach (Log log in logs)
        {
            GameObject currentLog = Instantiate(logDisplayPrefab, logsHolder);
            currentLog.GetComponent<LogHolder>().SetLog(log);
        }
    }
}
