using UnityEngine;

public class DefenseFinance : MonoBehaviour
{
    [SerializeField] public float defenseMoney; // The total defense money

    // Adds the specified amount of money to the defender
    public void AddToDefenderMoney(float moneyToAdd)
    {
        defenseMoney += moneyToAdd;
        Debug.Log($"Added {moneyToAdd} to defender money. Total {defenseMoney}");
    }
    public void RemoveDefenderMoney(float moneyToRemove)
    {
        defenseMoney -= moneyToRemove;
    }
}
