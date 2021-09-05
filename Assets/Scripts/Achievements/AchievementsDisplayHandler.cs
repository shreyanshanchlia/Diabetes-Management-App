using System.Collections.Generic;
using UnityEngine;

public class AchievementsDisplayHandler : MonoBehaviour
{
    [SerializeField] private Transform achievementsHolder;
    [SerializeField] private GameObject achievementsDisplayPrefab;
    List<Achievement> achievements; 
    private void Start()
    {
        ShowAchievements();
    }

    void ShowAchievementsCustomMainPanel()
    {
        LoadAchievements();
        DeleteExisting();
    }

    void ShowAchievements()
    {
        LoadAchievements();
        DeleteExisting();
        //SetFilters();
        DisplayAchievements();
    }
    public void LoadAchievements()
    {
        achievements = SaveSystem.GetUserData().achievements;
    }

    void DisplayAchievements()
    {
        foreach (Achievement achievement in achievements)
        {
            GameObject currentAchievement = Instantiate(achievementsDisplayPrefab, achievementsHolder);
            currentAchievement.GetComponent<AchievementHolder>().SetAchievement(achievement);
        }
    }
    void DeleteExisting()
    {
        int childs = achievementsHolder.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(achievementsHolder.GetChild(i).gameObject);
        }
    }
}
