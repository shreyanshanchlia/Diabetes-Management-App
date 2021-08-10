using System;
using System.Collections.Generic;
using System.Linq;

public static class AchievementsManager
{
    public static void GiveDailyAchievementsCheck()
    {
        AchievementCurrentDayBloodSugarLogCountCheck();
    }

    public static void AchievementCurrentDayBloodSugarLogCountCheck()
    {
        bool achievedCurrentDayBloodSugarLogCount = GetAchievements().Where(t =>
            SaveSystem.GetAchievement(t.achievementId).GetType() == typeof(AchievementBloodSugarLogCount)
        ).ToList().Count == 1;
        if (!achievedCurrentDayBloodSugarLogCount)
        {
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.SugarReading).ToList().Count >= SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.sugarLogCountTarget)
            {
                AchievementBloodSugarLogCount achievement = new AchievementBloodSugarLogCount();
                achievement.SetAchievement();
                SaveSystem.SaveUserAchievement(achievement.achievementId, achievement);
            }
        }
    }
    public static void AchievementCurrentDayInsulinTakenLogCountCheck()
    {
        bool achievedCurrentDayInsulinTakenLogCount = GetAchievements().Where(t =>
            SaveSystem.GetAchievement(t.achievementId).GetType() == typeof(AchievementInsulinCount)
        ).ToList().Count == 1;
        if (!achievedCurrentDayInsulinTakenLogCount)
        {
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.InsulinTaken).ToList().Count >= SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.insulinTakenLogCountTarget)
            {
                AchievementInsulinCount achievement = new AchievementInsulinCount();
                achievement.SetAchievement();
                SaveSystem.SaveUserAchievement(achievement.achievementId, achievement);
            }
        }
    }

    static List<Achievement> GetAchievements()
    {
        List<Achievement> achievements = SaveSystem.GetUserData().achievements;
        achievements = achievements.Where(t => t.achieveDateTime.Date == DateTime.Today).ToList();
        return achievements;
    }
    static List<Achievement> GetAchievements(DateTime date)
    {
        List<Achievement> achievements = SaveSystem.GetUserData().achievements;
        achievements = achievements.Where(t => t.achieveDateTime.Date == date.Date).ToList();
        return achievements;
    }
}
