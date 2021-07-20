using System;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using System.Globalization;
using UnityEngine;

public class InsulinTakenLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder startTime, insulinQuantity, insulinType;
    
    public void Submit()
    {
        try
        { 
            //log base
            log.logType = Log.LogType.InsulinTaken;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.ParseExact(startTime.GetString(), "HH:mm", CultureInfo.InvariantCulture);
            //custom log
            log.insulinQuantity = Convert.ToInt32(insulinQuantity.GetString());
            if (insulinType.GetString() == "1") log.typeOfInsulinTaken = Log.TypeOfInsulin.Bolus;
            if (insulinType.GetString() == "2") log.typeOfInsulinTaken = Log.TypeOfInsulin.Basil;

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
