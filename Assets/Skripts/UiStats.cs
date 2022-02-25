using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiStats : MonoBehaviour
{
   [SerializeField] private Text _HPUI;
   [SerializeField] private Text _ScoreUI;
   [SerializeField] private Text _LVLUI;
   [SerializeField] private Text _RecodUI;
    [SerializeField] private PlayerBehavior _playerBehavior;
    [SerializeField] private LVL _LVL;
    private void Start()
    {
        _playerBehavior.OnHPChange.AddListener((HP) =>
        {
            _HPUI.text = HP.ToString();
        });
        _playerBehavior.OnScoreChange.AddListener((Score) =>
        {
            _ScoreUI.text = Score.ToString();
              });
        _LVL.OnRecordChange.AddListener((Record) =>
        {
            _RecodUI.text = Record.ToString();
              });
        _LVL.OnLVLChange.AddListener((LVL) =>
        {
            _LVLUI.text = LVL.ToString();
              });     
    }
}
