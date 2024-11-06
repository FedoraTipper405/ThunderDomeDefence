using UnityEngine;

public class DefenseFinance : MonoBehaviour
{
    [SerializeField] private int defenseMoney; // The total defense money

    // Adds the specified amount of money to the defender
    public void AddToDefenderMoney(int moneyToAdd)
    {
        defenseMoney += moneyToAdd;
        Debug.Log($"Added {moneyToAdd} to defender money. Total {defenseMoney}");
    }
}
