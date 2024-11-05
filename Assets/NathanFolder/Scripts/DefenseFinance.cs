using UnityEngine;

public class DefenseFinance : MonoBehaviour
{
    int defenseMoney;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void AddToDefenderMoney(int moneyToAdd)
    {
        defenseMoney += moneyToAdd;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
