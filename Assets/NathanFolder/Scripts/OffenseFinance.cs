using UnityEngine;

public class OffenseFinance : MonoBehaviour
{
    int offenseMoney;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void AddToOffenseMoney(int moneyToAdd)
    {
        offenseMoney += moneyToAdd;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
