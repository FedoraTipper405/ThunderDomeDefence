using UnityEngine;
using System;

public class OffenseFinance : MonoBehaviour
{
    [SerializeField] public float offenseMoney; // Total money for the offense

    // Event that is triggered whenever money changes
    public event Action OnMoneyChanged;

    // Adds the specified amount of money to the offense
    public void AddToOffenseMoney(float moneyToAdd)
    {
        offenseMoney += moneyToAdd;
        OnMoneyChanged?.Invoke(); // Trigger the event to notify listenerse
        Debug.Log($"Added {moneyToAdd} to offenseMoney. Total: {offenseMoney}");
    }
    public void TakeAwayOffenseMoney(float moneyToRemove)
    {
        offenseMoney -= moneyToRemove;
    }

    // Method to get the current offense money
    public int GetOffenseMoney()
    {
        return Mathf.FloorToInt(offenseMoney);
    }
}
