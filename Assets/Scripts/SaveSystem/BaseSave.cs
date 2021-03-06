using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEditor;
using UnityEngine;

public static class BaseSave
{
    public static void PrefSave(string identifier, string value)
    {
        PlayerPrefs.SetString(identifier, value);
    }
    public static string PrefLoad(string identifier, string defaultValue)
    {
        return PlayerPrefs.GetString(identifier, "default");
    }
    #if UNITY_EDITOR
    [MenuItem("BaseSave/All/Clear")]
    public static void DeleteUserData()
    {
        SaveGame.Clear();
    }
    #endif
    public static void Save<T>(string identifier, T value)
    {
        if (!SaveGame.Exists(identifier))
        {
        }
        SaveGame.Save(identifier, value);
    }

    public static void SaveInList<T>(string identifier, T value)
    {
        List<T> prev;
        if (!SaveGame.Exists(identifier))
        {
            prev = new List<T>();
        }
        else
        {
            prev = SaveGame.Load<List<T>>(identifier);
        }
        prev.Add(value);
        SaveGame.Save(identifier, prev);
    }

    public static T Load<T>(string identifier, T defaultValue)
    {
        if (!SaveGame.Exists(identifier))
        {
            return defaultValue;
        }

        return SaveGame.Load<T>(identifier);
    }

    #region Identifiers

    public static string LOGS = "logs";
    public static string ACHIEVEMENTS = "achievements";
    public static string UNLOCKED = "unlocked";
    public static string SPARKLES = "sparkles";
    public static string XP = "xp";
    public static string DAILY_STREAK = "dailyStreak";

    public static string PREFS_EQUIPPEDCHARACTER = "equippedCharacter";

    #endregion
}
