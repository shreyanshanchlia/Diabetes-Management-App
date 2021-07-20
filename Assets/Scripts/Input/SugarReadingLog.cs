using System;
using System.Globalization;
using FantomLib;
using UnityEngine;

public class SugarReadingLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder sugarReading, startTime;
    
    public void Submit()
    {
        log.logType = Log.LogType.SugarReading;
        log.timeOfLog = DateTime.Now;
        log.startTime = DateTime.ParseExact(startTime.GetString(), "HH:mm", CultureInfo.InvariantCulture);
        log.sugarReading = Convert.ToInt32(sugarReading.GetString());
        
        #if UNITY_EDITOR
            Debug.Log("Sugar Reading Submitted");
        #else
            AndroidPlugin.ShowToast("Sugar Reading Submitted");
        #endif
    }
}
