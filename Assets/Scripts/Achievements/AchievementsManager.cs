using System;
using System.Collections.Generic;
using System.Linq;

public static class AchievementsManager
{
    public static void GiveDailyAchievementsCheck()
    {
        AchievementCurrentDayBloodSugarLogCountCheck();
        AchievementCurrentDayInsulinTakenLogCountCheck();
        AchievementCurrentDayActivityCountCheck();
        AchievementCurrentDayMealLogCheck();
    }

    public static void AchievementCurrentDayBloodSugarLogCountCheck()
    {
        bool achievedCurrentDayBloodSugarLogCount = GetAchievements().Where(t =>
            SaveSystem.GetAchievement(t.achievementId).GetType() == typeof(AchievementBloodSugarLogCount) && (SaveSystem.GetAchievement(t.achievementId) as Achievement)?.achieveDateTime == DateTime.Today
        ).ToList().Count == 1;
        if (!achievedCurrentDayBloodSugarLogCount)
        {
            int sugarLogCountTarget = SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.sugarLogCountTarget;
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.SugarReading).ToList().Count >= sugarLogCountTarget)
            {
                AchievementBloodSugarLogCount achievement = new AchievementBloodSugarLogCount();
                achievement.SetAchievement(name: "Daily Goal Completed", 
                    description: $"Blood Sugar Measured at least {sugarLogCountTarget} times");
                SaveSystem.SaveUserAchievement(achievement.achievementId, achievement);
            }
        }
    }
    public static void AchievementCurrentDayInsulinTakenLogCountCheck()
    {
        bool achievedCurrentDayInsulinTakenLogCount = GetAchievements().Where(t =>
            SaveSystem.GetAchievement(t.achievementId).GetType() == typeof(AchievementInsulinCount) && (SaveSystem.GetAchievement(t.achievementId) as Achievement)?.achieveDateTime == DateTime.Today
        ).ToList().Count == 1;
        if (!achievedCurrentDayInsulinTakenLogCount)
        {
            int insulinTakenLogCountTarget = SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.insulinTakenLogCountTarget;
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.InsulinTaken).ToList().Count >= insulinTakenLogCountTarget)
            {
                AchievementInsulinCount achievement = new AchievementInsulinCount();
                achievement.SetAchievement(name: "Daily Goal Completed", 
                    description: $"Insulin Taken at least {insulinTakenLogCountTarget} times");
                SaveSystem.SaveUserAchievement(achievement.achievementId, achievement);
            }
        }
    }
    public static void AchievementCurrentDayActivityCountCheck()
    {
        bool achievedCurrentDayActivityTimeCount = GetAchievements().Where(t =>
            SaveSystem.GetAchievement(t.achievementId).GetType() == typeof(AchievementActivityTime) && (SaveSystem.GetAchievement(t.achievementId) as Achievement)?.achieveDateTime == DateTime.Today
        ).ToList().Count == 1;
        if (!achievedCurrentDayActivityTimeCount)
        {
            int activityTimeTarget = SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.activityTimeTarget;
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.Activity).ToList().Count >= activityTimeTarget)
            {
                AchievementActivityTime achievement = new AchievementActivityTime();
                achievement.SetAchievement(name: "Daily Goal Completed", 
                    description: $"Activity at least {activityTimeTarget} times");
                SaveSystem.SaveUserAchievement(achievement.achievementId, achievement);
            }
        }
    }
    public static void AchievementCurrentDayMealLogCheck()
    {
        bool achievedCurrentDayMealCount = GetAchievements().Where(t =>
            SaveSystem.GetAchievement(t.achievementId).GetType() == typeof(AchievementMealLogCount) && (SaveSystem.GetAchievement(t.achievementId) as Achievement)?.achieveDateTime == DateTime.Today
        ).ToList().Count == 1;
        if (!achievedCurrentDayMealCount)
        {
            int mealCountTarget = SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.mealCountTarget;
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.Meal).ToList().Count >= mealCountTarget)
            {
                AchievementMealLogCount achievement = new AchievementMealLogCount();
                achievement.SetAchievement(name: "Daily Goal Completed", 
                    description: $"Meal taken at least {mealCountTarget} times");
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
