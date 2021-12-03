using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchievementsUI : MonoBehaviour
{
    [SerializeField] private GameObject achievementsPanelElement;
    [SerializeField] private List<Achievement> allAchievementsType;
    private void Start()
    {
        List<Achievement> achievements = BaseSave.Load(BaseSave.ACHIEVEMENTS, new List<Achievement>());
        foreach (Achievement _achievement in allAchievementsType)
        {
            if (achievements.Where(t => t.achievementID == _achievement.achievementID).ToList().Count > 0)
            {
                GameObject _achievementUI =
                    Instantiate(achievementsPanelElement, achievementsPanelElement.transform.parent);
                _achievementUI.GetComponent<AchievementHolder>().SetAchievement(_achievement, achievements.Where(
                    t => t.achievementID == _achievement.achievementID).ToList().Count);
            }
        }
        
        achievementsPanelElement.SetActive(false);
    }
}
