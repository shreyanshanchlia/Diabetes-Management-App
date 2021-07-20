using TMPro;
using UnityEngine;

public class LogHolder : MonoBehaviour
{
    public TextMeshProUGUI logType;
    public TextMeshProUGUI startTime;
    public TextMeshProUGUI otherData;

    public void SetLog(Log log)
    {
        logType.text = log.logType.ToString();
        startTime.text = $"{log.startTime.ToShortTimeString()} \n{log.startTime.ToLongDateString()}";

        if (log.logType == Log.LogType.SugarReading)
        {
            otherData.text = $"reading -> {log.sugarReading}";
        }
        else if (log.logType == Log.LogType.InsulinTaken)
        {
            otherData.text = $"{log.typeOfInsulinTaken} - {log.insulinQuantity} ml";
        }
        else if (log.logType == Log.LogType.Activity)
        {
            otherData.text = $"{log.intensityOfActivity} intensity";
        }
        else if (log.logType == Log.LogType.Meal)
        {
            otherData.text = $"{log.food}";
        }
        else if (log.logType == Log.LogType.Sleep)
        {
            otherData.text = $"to {log.endTime}";
        }
        else if (log.logType == Log.LogType.Hydration)
        {
            otherData.text = $"drank {log.glassesOfWater} glasses of water.";
        }
    }
}
