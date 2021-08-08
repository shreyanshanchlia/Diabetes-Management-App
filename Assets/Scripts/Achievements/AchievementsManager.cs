using System;
using System.Collections.Generic;
using System.Linq;
using BayatGames.SaveGameFree;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public void GiveDailyAchievementsCheck()
    {
        AchievementCurrentDayBloodSugarLogCountCheck();
    }

    public void AchievementCurrentDayBloodSugarLogCountCheck()
    {
        bool achievedCurrentDayBloodSugarLogCount = GetAchievements().Where(t =>
            SaveGame.Load<dynamic>($"Achievement{t.achievementId}").GetType() == typeof(AchievementBloodSugarLogCount)
        ).ToList().Count == 1;
        if (!achievedCurrentDayBloodSugarLogCount)
        {
            if (SaveSystem.GetUserData().logs.Where(t => t.timeOfLog == DateTime.Today && t.logType == Log.LogType.SugarReading).ToList().Count >= SaveSystem.GetUserInfo().preferences.dailyChallengePreferences.sugarLogCountTarget)
            {
                AchievementBloodSugarLogCount achievement = new AchievementBloodSugarLogCount();
                achievement.SetAchievement();
            }
        }
    }

    List<Achievement> GetAchievements()
    {
        List<Achievement> achievements = SaveSystem.GetUserData().achievements;
        achievements = achievements.Where(t => t.achieveDateTime.Date == DateTime.Today).ToList();
        return achievements;
    }
    List<Achievement> GetAchievements(DateTime date)
    {
        List<Achievement> achievements = SaveSystem.GetUserData().achievements;
        achievements = achievements.Where(t => t.achieveDateTime.Date == date.Date).ToList();
        return achievements;
    }
}
