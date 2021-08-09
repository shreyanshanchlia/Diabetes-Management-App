using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AchievementsManager
{
    public static void GiveDailyAchievementsCheck()
    {
        AchievementCurrentDayBloodSugarLogCountCheck();
    }

    public static void AchievementCurrentDayBloodSugarLogCountCheck()
    {
        Debug.Log("Mein nahi chalunga");
        bool achievedCurrentDayBloodSugarLogCount = GetAchievementsPresentDay()
            .Where(t => t.achievementMode == Achievement.AchievementMode.DailyChallenge 
                        && t.dailyChallenge == Achievement.DailyChallenge.BloodSugarLogCount).ToList().Count == 1;
        Debug.Log("achievedCurrentDayBloodSugarLogCount " + achievedCurrentDayBloodSugarLogCount);
        if (!achievedCurrentDayBloodSugarLogCount)
        {
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.SugarReading).ToList().Count >= SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.sugarLogCountTarget)
            {
                Achievement achievement = new Achievement();
                achievement.SetAchievement(Achievement.AchievementMode.DailyChallenge, Achievement.DailyChallenge.BloodSugarLogCount,"");
                SaveSystem.SaveUserData(achievement);
            }
        }
    }

    static List<Achievement> GetAchievementsPresentDay()
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
