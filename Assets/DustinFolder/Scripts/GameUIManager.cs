using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("UI Text Elements")]
    [SerializeField] private TMP_Text moneyText; // UI element for displaying money
    [SerializeField] private TMP_Text turnRoleText; // UI element for displaying turn and role information
    [SerializeField] private TMP_Text waveCounterText; // UI element for displaying the wave counter
    [SerializeField] private TMP_Text playerText; // UI element for displaying current player (Player 1 or Player 2)

    [Header("Finance References")]
    [SerializeField] private DefenseFinance defenseFinance;
    [SerializeField] private OffenseFinance offenseFinance;

    public bool isDefenseTurn = true; // Keeps track of whose turn it is
    public bool isPlayerOneTurn = true; // Keeps track of whose player turn it is
    private int waveCounter = 1; // Counter for the current wave

    private void Start()
    {
        // Subscribe to money changed events
        if (defenseFinance != null)
        {
            defenseFinance.OnMoneyChanged += UpdateUI;
        }

        if (offenseFinance != null)
        {
            offenseFinance.OnMoneyChanged += UpdateUI;
        }
        
        UpdateUI(); // Initial UI update
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        if (defenseFinance != null)
        {
            defenseFinance.OnMoneyChanged -= UpdateUI;
        }

        if (offenseFinance != null)
        {
            offenseFinance.OnMoneyChanged -= UpdateUI;
        }
    }

    public void UpdateUI()
    {
        // Update money based on whose turn it is
        if (isDefenseTurn)
        {
            moneyText.text = $"Defense Money: {(int)defenseFinance.GetDefenseMoney()}";
        }
        else
        {
            moneyText.text = $"Offense Money: {(int)offenseFinance.GetOffenseMoney()}";
        }

        // Update turn and role text
        string role = isDefenseTurn ? "Defense" : "Offense";
        turnRoleText.text = $"Current Turn: {role}";

        // Update wave counter text
        waveCounterText.text = $"Wave: {waveCounter}";

        // Update player text
        playerText.text = isPlayerOneTurn ? "Player 1" : "Player 2";
    }

    // Call this method to swap turns and roles
    public void SwapTurn()
    {
        isDefenseTurn = !isDefenseTurn;
        UpdateUI();
    }

    // Call this method to swap players
    public void SwapPlayer()
    {
        isPlayerOneTurn = !isPlayerOneTurn;
        UpdateUI();
    }

    // Call this method to increment the wave counter
    public void IncrementWaveCounter()
    {
        waveCounter++;
        UpdateUI();
    }

    // Method to check if it is currently the defense's turn
    public bool IsDefenseTurn()
    {
        return isDefenseTurn;
    }
}
