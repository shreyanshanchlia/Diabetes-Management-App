using System;

public class Log
{
    public enum LogType
    {
        SugarReading,
        InsulinTaken,
        Activity,
        Meal,
        Sleep,
        Hydration
    }

    public enum TypeOfInsulin
    {
        Bolus,
        Basil
    }

    public enum IntensityOfActivity
    {
        Low,
        Medium,
        High
    }

    public LogType logType;

    public DateTime timeOfLog;
    public DateTime startTime;

    //data for each type of log

    //sugar reading
    public int sugarReading;

    //insulin taken
    public TypeOfInsulin typeOfInsulinTaken;
    public int insulinQuantity;

    //activity
    public IntensityOfActivity intensityOfActivity;

    //activity and sleep
    public DateTime endTime;

    //meal
    public string food;

    //hydration
    public int glassesOfWater;
}
