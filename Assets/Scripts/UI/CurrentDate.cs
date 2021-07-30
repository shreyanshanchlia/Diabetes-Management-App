using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentDate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentDateText;
    [Tooltip("Update occurs every 1 second")]
    [SerializeField] private bool update;

    private void Start()
    {
        SetCurrentDate();
        if (update)
        {
            InvokeRepeating(nameof(UpdateSecond), 1f, 1f);
        }
    }

    private void UpdateSecond()
    {
        SetCurrentDate();
    }

    void SetCurrentDate()
    {
        currentDateText.text = DateTime.Today.ToLongDateString();
    }
    
    private void OnValidate()
    {
        SetCurrentDate();
    }

}
