using UnityEngine;

public class OffenseFinance : MonoBehaviour
{
    [SerializeField] public float offenseMoney; // Total money for the offense

    // Adds the specified amount of money to the offense
    public void AddToOffenseMoney(float moneyToAdd)
    {
        offenseMoney += moneyToAdd;
        Debug.Log($"Added {moneyToAdd} to offenseMoney. Total: {offenseMoney}");
    }
    public void TakeAwayOffenseMoney( float moneyToRemove)
    {
        offenseMoney -= moneyToRemove;
    }
}
