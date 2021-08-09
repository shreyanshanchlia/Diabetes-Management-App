using System.Collections.Generic;
using System.Linq;
using BayatGames.SaveGameFree;
using UnityEditor;
using UnityEngine;


public static class SaveSystem
{
    #region User Info
    public static void SaveUserInfo(UserInfo userInfo)
    {
        SaveGame.Save("userInfo", userInfo);
#if UNITY_EDITOR        
        PrintUserInfo();
#endif
    }

    public static UserInfo GetUserInfo()
    {
        if (SaveGame.Exists("userInfo"))
        {
            return SaveGame.Load<UserInfo>("userInfo");
        }
        return new UserInfo();
    }

#if UNITY_EDITOR
    [MenuItem("SaveSystem/UserInfo/Print")]
    public static void PrintUserInfo()
    {
        UserInfo userInfo = SaveGame.Load("userInfo", new UserInfo());
        Debug.Log($"user info - \n{userInfo.name}, {userInfo.age}, {userInfo.gender}, {userInfo.weight}, {userInfo.height}");
    }

    [MenuItem("SaveSystem/UserInfo/Delete")]
    public static void DeleteUserInfo()
    {
        SaveGame.Delete("userInfo");
    }
#endif
    #endregion


    #region credentials
    public static void SaveUserCredentials(Credentials credentials)
    {
        SaveGame.Save("credentials", credentials);
#if UNITY_EDITOR
        PrintUserCredentials();
#endif
    }
    
#if UNITY_EDITOR
    [MenuItem("SaveSystem/Credentials/Print")]
    public static void PrintUserCredentials()
    {
        Credentials credentials = SaveGame.Load("credentials", new Credentials());
        Debug.Log($"credentials - \n{credentials.email}, {credentials.password}");
    }
    
    [MenuItem("SaveSystem/Credentials/Delete")]
    public static void DeleteUserCredentials()
    {
        SaveGame.Delete("credentials");
    }
#endif
    #endregion
    
    
    #region user_data
    public static void SaveUserData(Log log)
    {
        UserData userData = SaveGame.Load("userData", new UserData());
        
        if (userData.logs == null) userData.logs = new List<Log>();
        userData.logs.Add(log);
        
        SaveGame.Save("userData", userData);
        #if UNITY_EDITOR
        PrintUserData();
        #endif
    }

    public static void SaveUserData(Achievement achievement)
    {
        UserData userData = SaveGame.Load("userData", new UserData());

        if (userData.achievements == null)
        {
            userData.achievements = new List<Achievement>();
        }
        userData.achievements.Add(achievement);
        
        SaveGame.Save("userData", userData);
    }

    public static void SaveUserAchievement(int achievementId, dynamic achievement)
    {
        SaveGame.Save<dynamic>($"Achievement{achievementId}", achievement);
        
        Debug.Log(typeof(Achievement).ToString());
    }

    public static UserData GetUserData()
    {
        if (!SaveGame.Exists("userData"))
        {
            return new UserData();
        }
        return SaveGame.Load("userData", new UserData());
    }

    public static dynamic GetAchievement(int achievementId)
    {
        if (SaveGame.Exists($"Achievement{achievementId}"))
        {
            return SaveGame.Load<dynamic>($"Achievement{achievementId}");
        }
        return null;
    }
    
    #if UNITY_EDITOR
    [MenuItem("SaveSystem/UserData/PrintLatest")]
    public static void PrintUserData()
    {
        UserData userData = SaveGame.Load("userData", new UserData());
        Debug.Log($"LatestUserData - \n{userData.logs[userData.logs.Count-1].logType}");
        Debug.Log($"Achievement0 = {SaveGame.Load($"Achievement0", new Achievement()).achieveDateTime}");
        Debug.Log($"Latest Achievement - \n{userData.achievements[userData.achievements.Count-1].achievementId}");
    }
    
    [MenuItem("SaveSystem/UserData/DeleteUserData")]
    public static void DeleteUserData()
    {
        SaveGame.Delete("userData");
    }
    [MenuItem("SaveSystem/UserData/DeleteAchievements")]
    public static void DeleteAchievementsData()
    {
        var userData = SaveGame.Load("userData", new UserData());
        int achievementsCount = userData.achievements.OrderByDescending(t => t.achievementId).First().achievementId;
        userData.achievements = new List<Achievement>();
        SaveGame.Save("userData", userData);
        for (int i = 0; i < achievementsCount; i++)
        {
            SaveGame.Delete($"Achievement{i}");
        }
    }
    #endif
    
    #endregion
}


public struct Credentials
{
    public string email;
    public string password;
}

public struct UserInfo
{
    public enum Gender{Male, Female, Other}
    
    public string name;
    public int age;
    public Gender gender;
    public float weight;    //in kgs
    public float height;    //in inches
    
    public Preferences preferences;
}

public struct Preferences
{
    public DailyChallengePreferences dailyChallengePreferences;
    public struct DailyChallengePreferences
    {
        public int sugarLogCountTarget;
    }
}

public struct UserData
{
    public List<Log> logs;
    public List<Achievement> achievements;
}