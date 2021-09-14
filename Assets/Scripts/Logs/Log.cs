using System;

[Serializable]
public struct Log
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

    public struct NutritionalValue
    {
        public string Carbs;
        public string Fat;
        public string Protein;
        public string Fiber;
    }

    public int logId; 
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
    public NutritionalValue nutritionalValue;

    //hydration
    public int glassesOfWater;
}
