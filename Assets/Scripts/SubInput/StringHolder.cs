using System;
using TMPro;
using UnityEngine;

public class StringHolder : MonoBehaviour
{
    private string holder;
    [SerializeField] private DefaultString defaultString;
    [SerializeField] private bool setText;
    [SerializeField] private TextMeshProUGUI ShowStringText;

    public enum DefaultString
    {
        None,
        Time,
        Date
    };
    
    public void SetString(string text)
    {
        holder = text;
        if (setText)
        {
            ShowStringText.text = text;
        }
    }

    void SetDefaultString()
    {
        if (defaultString == DefaultString.Date)
        {
            SetString(DateTime.Now.ToShortDateString());
        }
        if (defaultString == DefaultString.Time)
        {
            SetString(DateTime.Now.ToShortTimeString());
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
