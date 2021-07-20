using System;
using System.Collections.Generic;
using UnityEngine;

public class BackHandler : MonoBehaviour
{
    public Queue<RectTransform> panels;
    public RectTransform dashboard;

    private void Start()
    {
        panels = new Queue<RectTransform>();
        BackInterface();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackInterface();
        }
    }

    public void BackInterface()
    {
        if (panels.Count > 0)
        {
            RectTransform prevPanel = panels.Dequeue();
            prevPanel.SetAsLastSibling();
        }
        else
        {
            dashboard.SetAsLastSibling();
        }
    }
}
