using UnityEngine;

public class OffenseFinance : MonoBehaviour
{
    [SerializeField] private int offenseMoney; // Total money for the offense

    // Adds the specified amount of money to the offense
    public void AddToOffenseMoney(int moneyToAdd)
    {
        offenseMoney += moneyToAdd;
        Debug.Log($"Added {moneyToAdd} to offenseMoney. Total: {offenseMoney}");
    }
}
