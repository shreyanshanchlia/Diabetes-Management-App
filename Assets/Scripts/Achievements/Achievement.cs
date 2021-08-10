using System;

public class Achievement
{
    public int achievementId;
    public DateTime achieveDateTime;
    public string achievementName;
    public string achievementDescription;
    
    public virtual void SetAchievement(string description = "", string name = "")
    {
        achievementId = SaveSystem.GetUserData().achievements.Count;
        achieveDateTime = DateTime.Now;
        achievementDescription = description;
        achievementName = name;
        
        SaveSystem.SaveUserData(this);
    }
}

public class DailyAchievement : Achievement
{
    
}

public class AchievementBloodSugarLogCount : DailyAchievement
{
    
}

public class AchievementInsulinCount : DailyAchievement
{
    
}

public class AchievementActivityTime : DailyAchievement
{
    
}

public class AchievementMealLogCount : DailyAchievement
{
    
}

public class AchievementSleepTime : DailyAchievement
{
    
}

public class AchievementHydrated : DailyAchievement
{
    
}

public class AchievementAllDailyChallengeCompleted : DailyAchievement
{
    
}
