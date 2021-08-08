using UnityEngine;

public class Achievement : MonoBehaviour
{
    public enum AchievementType
    {
        DailyChallenge
    }

    public AchievementType achievementType;
    public DailyChallenge 
    public string achievementDescription;
    
    public enum DailyChallenge
    {
        None,
        BloodSugarCountAccomplished,
        InsulinCountAccomplished,
        ActivityTimeAccomplished,
        MealLogAccomplished,
        SleepTimeAccomplished,
        HydrationAccomplished,
        CompletedAllDailyAchievements
    }
}
