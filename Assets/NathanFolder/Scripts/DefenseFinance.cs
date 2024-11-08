using UnityEngine;
using System;

public class DefenseFinance : MonoBehaviour
{
    [SerializeField] public float defenseMoney; // The total defense money

    // Event that is triggered whenever money changes
    public event Action OnMoneyChanged;

    // Adds the specified amount of money to the defender
    public void AddToDefenderMoney(float moneyToAdd)
    {
        defenseMoney += moneyToAdd;
        OnMoneyChanged?.Invoke(); // Trigger the event to notify listeners
        Debug.Log($"Added {moneyToAdd} to defender money. Total {defenseMoney}");
    }
    public void RemoveDefenderMoney(float moneyToRemove)
    {
        defenseMoney -= moneyToRemove;
    }

    // Method to get the current defense money
    public int GetDefenseMoney()
    {
        return Mathf.FloorToInt(defenseMoney);
    }
}
