using System;
using TMPro;
using UnityEngine;

public class StringHolder : MonoBehaviour
{
    private string holder;
    [SerializeField] private DefaultString defaultString;
    [SerializeField] private bool setText;
    [SerializeField] private TextMeshProUGUI ShowStringText;
    [SerializeField] private string customText;

    public enum DefaultString
    {
        None,
        Time,
        Date,
        Custom
    };
    
    public void SetString(string text)
    {
        holder = text;
        if (setText)
        {
            ShowStringText.text = text;
        }
    }

    public void SetString(int text)
    {
        SetString(text.ToString());
    }

    void SetDefaultString()
    {
        if (defaultString == DefaultString.Date)
        {
            SetString(DateTime.Now.ToShortDateString());
        }
        if (defaultString == DefaultString.Time)
        {
            SetString(DateTime.Now.ToString("H:mm"));
        }
        if (defaultString == DefaultString.Custom)
        {
            SetString(customText);
        }
    }
    private void Start()
    {
        SetDefaultString();
    }

    public string GetString()
    {
        return holder;
    }
}
