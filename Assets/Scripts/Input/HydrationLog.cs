using System;
using System.Globalization;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using UnityEngine;

public class HydrationLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder waterDrank;
    
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
            
            SaveSystem.SaveUserData(log);
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