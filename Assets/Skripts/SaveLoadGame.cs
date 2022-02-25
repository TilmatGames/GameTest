using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadGame : MonoBehaviour
{
    public void SaveGame()
    {
        PlayerPrefs.SetInt("lvl", SettingLVL.LVL);
        PlayerPrefs.SetInt("SpeedMonstr", SettingLVL.SpeedMonstr);
        PlayerPrefs.SetInt("ApplesScore", PlayerStats.ApplesScore);
        PlayerPrefs.SetInt("HP", PlayerStats.HP);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        SettingLVL.LVL = PlayerPrefs.GetInt("lvl");
        SettingLVL.SpeedMonstr = PlayerPrefs.GetInt("SpeedMonstr");
        PlayerStats.ApplesScore = PlayerPrefs.GetInt("ApplesScore");
        PlayerStats.HP = PlayerPrefs.GetInt("HP");
        Debug.Log("Game data loaded!");
    }
    [ContextMenu("ClearSaves")]
    public void ClearAllSaves()
    {
        PlayerPrefs.SetInt("lvl", 0);
        PlayerPrefs.SetInt("SpeedMonstr", 4);
        PlayerPrefs.SetInt("ApplesScore", 0);
        PlayerPrefs.SetInt("HP", 3);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

}
