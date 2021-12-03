using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "Achievements/New")]
public class Achievement : ScriptableObject
{
    public string achievementID = "";
    public Sprite achievementLogo;
    public string achievementName;
    public string achievementDescription;
    [HideInInspector] public DateTime timeOfAchievement;
}

public class DailyStreak
{
    public DateTime startDate = DateTime.Today;
    public DateTime lastUpdated = DateTime.Today.AddDays(-1);
    public uint streakLength = 0;
    public uint longestStreak = 0;
}
