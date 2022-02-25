using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehavior : MonoBehaviour
{
    public UnityEvent<int> OnHPChange;
    public UnityEvent<int> OnScoreChange;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            SettingLVL.ApplesCount++;
            PlayerStats.ApplesScore++;
            OnScoreChange.Invoke(PlayerStats.ApplesScore);
            col.gameObject.SetActive(false);

        }
        if (col.CompareTag("Enemy"))
        {
           
            PlayerStats.HP--;
            OnHPChange.Invoke(PlayerStats.HP);
        }
    }
}
