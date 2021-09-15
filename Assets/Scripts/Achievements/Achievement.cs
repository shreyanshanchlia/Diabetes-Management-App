using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "Achievements/New")]
public class Achievement : ScriptableObject
{
    public string achievementID;
    public Sprite achievementLogo;
    public string achievementName;
    public string achievementDescription;
}
