using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DashboardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberOfAchievementsText;
    [SerializeField] private TextMeshProUGUI dailyStreakText;
    [SerializeField] private TextMeshProUGUI sparklesText;
    [SerializeField] private TextMeshProUGUI xpText;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateSecond), 0f, 1f);
    }

    private void UpdateSecond()
    {
        //update numberOfAchievementsText
        List<Achievement> achievements = BaseSave.Load(BaseSave.ACHIEVEMENTS, new List<Achievement>());
        if (achievements.Count == 0)
        {
            Achievement achievement = new Achievement();
            BaseSave.SaveInList(BaseSave.ACHIEVEMENTS, achievement);
        }
        achievements = BaseSave.Load(BaseSave.ACHIEVEMENTS, new List<Achievement>());
        numberOfAchievementsText.text = BaseSave.Load(BaseSave.ACHIEVEMENTS, achievements)
            .Count(t => !string.IsNullOrEmpty(t.achievementID)).ToString();
        
        //update dailyStreakText
        bool safe = AchievementsManager.CheckDailyStreakSafety();
        DailyStreak _currentStreak = BaseSave.Load(BaseSave.DAILY_STREAK, new DailyStreak());
        if (safe) dailyStreakText.text = $"{_currentStreak.streakLength}";
        else dailyStreakText.text = $"<color=red>{_currentStreak.streakLength}";
        
        //update sparklesText
        sparklesText.text = BaseSave.Load(BaseSave.SPARKLES, 0).ToString();

        //update xpText
    }
}
