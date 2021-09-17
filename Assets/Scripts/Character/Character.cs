using UnityEngine;

[CreateAssetMenu(fileName = "Character_", menuName = "Characters/New")]
public class Character : ScriptableObject
{
    public string characterId;
    public Sprite image;
    public int unlockCost;
    public string characterName;
    [TextArea] public string characterDescription;
}
