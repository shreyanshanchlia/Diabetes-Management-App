using System;
using UnityEngine;

public class NavigationHandler : BackHandler
{
    private GameObject activePanel;
    public static NavigationHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroyActivePanel();
            //BackInterface();
        }
    }
    
    public void LoadPanel(GameObject panelPrefab)
    {
        activePanel = Instantiate(panelPrefab, this.transform);
    }

    public void DestroyActivePanel()
    {
        if (activePanel != null)
        {
            Destroy(activePanel.gameObject);
        }
    }
}
