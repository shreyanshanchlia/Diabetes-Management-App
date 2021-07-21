using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelHandler : MonoBehaviour
{
    public void ClosePanel()
    {
        NavigationHandler.instance.DestroyActivePanel();
    }
}
