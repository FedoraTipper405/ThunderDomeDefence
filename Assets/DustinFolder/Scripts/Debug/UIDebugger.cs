using UnityEngine;

public class UIDebugController : MonoBehaviour
{
    [SerializeField] private GameUIManager gameUIManager; // Reference to the GameUIManager script
    [SerializeField] private DefenseFinance defenseFinance;
    [SerializeField] private OffenseFinance offenseFinance;

    private void Update()
    {
        // Press T to swap turns and roles
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameUIManager.SwapTurn();
        }

        // Press W to increment the wave counter
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameUIManager.IncrementWaveCounter();
        }

        // Press E to give money to the current team
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameUIManager.IsDefenseTurn())
            {
                defenseFinance.AddToDefenderMoney(100); // Adds 100 money to the defense
                Debug.Log("Added 100 to defense money");
            }
            else
            {
                offenseFinance.AddToOffenseMoney(100); // Adds 100 money to the offense
                Debug.Log("Added 100 to offense money");
            }
        }

        // Press Q to take away money from the current team
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gameUIManager.IsDefenseTurn())
            {
                defenseFinance.AddToDefenderMoney(-100); // Subtracts 100 money from the defense
                Debug.Log("Subtracted 100 from defense money");
            }
            else
            {
                offenseFinance.AddToOffenseMoney(-100); // Substracts 100 money from the offense
                Debug.Log("Subtracted 100 from offense money");
            }
        }

        // Press F to update player text
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameUIManager.SwapPlayer();
            Debug.Log("Updated player text");
        }
    }
}
