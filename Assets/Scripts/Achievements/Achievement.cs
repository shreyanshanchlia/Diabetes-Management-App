using System;

public class Achievement
{
    public int achievementId;
    public DateTime achieveDateTime;
    public string achievementDescription;
    public AchievementMode achievementMode;
    public DailyChallenge dailyChallenge;
    
    public virtual void SetAchievement(AchievementMode _achievementMode, DailyChallenge _dailyChallenge, string description = "")
    {
        achievementId = SaveSystem.GetUserData().achievements.Count;
        achieveDateTime = DateTime.Now;
        achievementDescription = description;
        achievementMode = _achievementMode;
        dailyChallenge = _dailyChallenge;
        
        SaveSystem.SaveUserData(this);
    }

    public enum AchievementMode
    {
        DailyChallenge,
        Challenges
    }

    public enum DailyChallenge
    {
        None,
        BloodSugarLogCount
    }
}