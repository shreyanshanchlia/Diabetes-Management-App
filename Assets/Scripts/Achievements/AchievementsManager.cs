using System;
using System.Collections.Generic;
using System.Linq;
using FantomLib;
using UnityEngine;
using Random = UnityEngine.Random;

public class AchievementsManager : MonoBehaviour
{
    public static void CheckAddAchievement(Achievement dailyLogAchievement)
    {
        DailyStreakIncremented();
        List<Achievement> achievements = BaseSave.Load(BaseSave.ACHIEVEMENTS, new List<Achievement>());
        if (achievements.Count == 0)
        {
            Achievement achievement = new Achievement();
            BaseSave.SaveInList(BaseSave.ACHIEVEMENTS, achievement);
        }
        achievements = BaseSave.Load(BaseSave.ACHIEVEMENTS, new List<Achievement>());
        if (achievements.Where(t => t.achievementID == dailyLogAchievement.achievementID)
            .Count(t => t.timeOfAchievement == DateTime.Today) == 0)
        {
            dailyLogAchievement.timeOfAchievement = DateTime.Today;
            BaseSave.SaveInList(BaseSave.ACHIEVEMENTS, dailyLogAchievement);
            
#if !UNITY_EDITOR && UNITY_ANDROID
            AndroidPlugin.ShowToast($"Achievement Unlocked!\n{dailyLogAchievement.achievementName}");
#endif
        }
        else
        {
            int foundSparkles = Random.Range(0, 5);
            BaseSave.Save(BaseSave.SPARKLES, BaseSave.Load(BaseSave.SPARKLES, 0) + foundSparkles);
            
#if !UNITY_EDITOR && UNITY_ANDROID
            AndroidPlugin.ShowToast($"Found {foundSparkles} Sparkles!");
#endif
        }
    }

    public static void DailyStreakIncremented()
    {
        DailyStreak _dailyStreak = BaseSave.Load(BaseSave.DAILY_STREAK, new DailyStreak());
        
        //add a day.
        if (_dailyStreak.lastUpdated.Date == DateTime.Today.AddDays(-1).Date)
        {
            _dailyStreak.lastUpdated = DateTime.Today;
            _dailyStreak.streakLength++;
            if (_dailyStreak.longestStreak < _dailyStreak.streakLength)
            {
                _dailyStreak.longestStreak = _dailyStreak.streakLength;
            }
        }
        //streak lost
        else if (_dailyStreak.lastUpdated.Date < DateTime.Today.AddDays(-1).Date)
        {
            _dailyStreak.startDate = DateTime.Today;
            _dailyStreak.lastUpdated = DateTime.Today;
            _dailyStreak.longestStreak = _dailyStreak.longestStreak;
            _dailyStreak.streakLength = 1;
        }
        //already updated
        else if (_dailyStreak.lastUpdated.Date == DateTime.Today.Date)
        {
            //do nothing
        }
        
        BaseSave.Save(BaseSave.DAILY_STREAK, _dailyStreak);
    }

    /// <summary>
    /// Checks and updates streak
    /// </summary>
    /// <returns>returns true if safe, false if danger safe</returns>
    public static bool CheckDailyStreakSafety()
    {
        DailyStreak _dailyStreak = BaseSave.Load(BaseSave.DAILY_STREAK, new DailyStreak());
        if (_dailyStreak.lastUpdated.Date < DateTime.Today.AddDays(-1).Date)
        {
            _dailyStreak.startDate = DateTime.Today;
            _dailyStreak.lastUpdated = DateTime.Today.AddDays(-1);
            _dailyStreak.longestStreak = _dailyStreak.longestStreak;
            _dailyStreak.streakLength = 0;
            BaseSave.Save(BaseSave.DAILY_STREAK, _dailyStreak);
        }
        else if (_dailyStreak.lastUpdated.Date == DateTime.Today.AddDays(-1).Date)
        {
            return false;
        }
        return true;
    }
}
