using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseSetting : MonoBehaviour
{
    
    public void OpenClose(GameObject panel) 
    {
        if (panel.activeInHierarchy)  panel.SetActive(false); else panel.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
