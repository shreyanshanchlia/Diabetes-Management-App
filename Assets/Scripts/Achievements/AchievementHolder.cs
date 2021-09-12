using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI achievementCount;
    [SerializeField] private TextMeshProUGUI achievementName;
    [SerializeField] private TextMeshProUGUI achievementDescription;
    [SerializeField] private TextMeshProUGUI achievementLastDate;
    [SerializeField] private GameObject CountImage;
    [SerializeField] private Image AchievementLogo;

    // public void SetAchievement(Achievement achievement, int count = 1)
    // {
    //     CountImage.SetActive(true);
    //     achievementCount.text = count.ToString();
    //     achievementName.text = achievement.achievementName;
    //     achievementDescription.text = achievement.achievementDescription;
    //     achievementLastDate.text = $"{achievement.achieveDateTime.ToShortDateString()}";
    //     //AchievementLogo.sprite = set logo
    // }
    // public void SetAchievement(Achievement achievement)
    // {
    //     CountImage.SetActive(false);
    //     achievementName.text = achievement.achievementName;
    //     achievementDescription.text = achievement.achievementDescription;
    //     achievementLastDate.text = $"{achievement.achieveDateTime.ToShortDateString()}";
    //     //AchievementLogo.sprite = set logo
    // }
}
