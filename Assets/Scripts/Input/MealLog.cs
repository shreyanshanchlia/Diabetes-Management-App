using System;
using System.Globalization;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using UnityEngine;

public class MealLog : MonoBehaviour
{
    private Log log;

    [SerializeField] private StringHolder mealTaken, startTime;
    [SerializeField] private StringHolder nCarbs, nFat, nProtein, nFiber;
    
    public void Submit()
    {
        try
        {
            //log base
            log.logType = Log.LogType.Meal;
            log.timeOfLog = DateTime.Now;
            log.startTime = DateTime.ParseExact(startTime.GetString(), "H:mm", CultureInfo.InvariantCulture);
            
            //custom log
            log.food = mealTaken.GetString();
            
            log.nutritionalValue = new Log.NutritionalValue();
            log.nutritionalValue.Carbs = nCarbs.GetString();
            log.nutritionalValue.Fat = nFat.GetString();
            log.nutritionalValue.Protein = nProtein.GetString();
            log.nutritionalValue.Fiber = nFiber.GetString();
            
            //SaveSystem.SaveUserData(log);
            BaseSave.SaveInList(BaseSave.LOGS, log);
            
#if UNITY_EDITOR
            Debug.Log("Meal Submitted");
#else
            AndroidPlugin.ShowToast($"Meal Submitted\n{log.startTime}");
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