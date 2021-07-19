using TMPro;
using UnityEngine;

public class StringHolder : MonoBehaviour
{
    private string holder;
    [SerializeField] private bool setText;
    [SerializeField] private TextMeshProUGUI ShowStringText;
    public void SetString(string text)
    {
        holder = text;
        if (setText)
        {
            ShowStringText.text = text;
        }
    }

    public string GetString()
    {
        return holder;
    }
}
