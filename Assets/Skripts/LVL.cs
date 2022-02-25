using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LVL : MonoBehaviour
{
    [SerializeField] private GameObject _MessageNextLVL, _MessageGameOver;
    [SerializeField] private GameObject[] _newPositiongameObjects;
    [SerializeField] private Text _messageText;
    public UnityEvent<int> OnLVLChange;
    public UnityEvent<int> OnRecordChange;

    void Update()
    {
        if (SettingLVL.ApplesCount == SettingLVL.AppleslvlUp)
        {
            NextLVL();
        }
        if (PlayerStats.HP <= 0)
        {
            GameOver();
        }
    }

    private void Start()
    {
        OnRecordChange.Invoke(SettingLVL.Record);
    }

    private void NextLVL() //поднимаем уровень и сложность
    {
        _MessageNextLVL.SetActive(true);
        foreach (GameObject NewPositiongameObjects in _newPositiongameObjects)
        {
            NewPositiongameObjects.SetActive(true);
            float rndx = UnityEngine.Random.Range(-20, 19);
            float rndy = UnityEngine.Random.Range(-21, 21);
            NewPositiongameObjects.transform.position = new Vector2(rndx, rndy);
        }
        SettingLVL.LVL++;
        SettingLVL.ApplesCount = 0;
        SettingLVL.SpeedMonstr++;
        OnLVLChange.Invoke(SettingLVL.LVL);
        _messageText.text = "Новый уровень";
        Pause();
    }


    private void GameOver()  //игра окончена
    {
        SaveRecord();
        _MessageGameOver.SetActive(true);
     
        Pause();
    }
    public void GameRestart()
    {
        PlayerStats.HP = 3;
        SettingLVL.SpeedMonstr = 4;
        PlayerStats.ApplesScore = 0;
        SettingLVL.LVL = 1;
        SceneManager.LoadScene("main");
    }

    private void Pause()
    {
        Time.timeScale = 0;

    }
    public void Play()
    {
        Time.timeScale = 1;
    }
    public void SaveRecord() //сохраняем рекорд

    {

        if (PlayerStats.ApplesScore > SettingLVL.Record)
        {
           
            SettingLVL.Record = PlayerStats.ApplesScore;
            
            PlayerPrefs.SetInt("Record", SettingLVL.Record);
            OnRecordChange.Invoke(SettingLVL.Record);
            PlayerPrefs.Save();
        }


    }

}
