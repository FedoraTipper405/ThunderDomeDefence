using JetBrains.Annotations;
using UnityEngine;

public class EnemyRewardTracker : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData; // Reference to the EnemyData SO

    private OffenseFinance offenseFinance; // Reference to the OffenseFinance script
    private float distanceTraveled = 0f; // Track how far the enemy has traveled
    private float timeSurvived = 0f; // Track how long the enemy has survived
    private Vector3 lastPosition;

    private void Start()
    {
        // Automatically find the OffenseFinance component in the scene
        offenseFinance = Object.FindFirstObjectByType<OffenseFinance>();

        if (offenseFinance == null)
        {
            Debug.LogError("OffenseFinance component not found in the scene!");
        }

        lastPosition = transform.position;
    }

    private void Update()
    {
        if (offenseFinance == null || enemyData == null) return;

        // Track how long the enemy has been alive
        timeSurvived += Time.deltaTime;

        // Track how far the enemy has moved
        distanceTraveled += Vector3.Distance(lastPosition, transform.position);
        lastPosition = transform.position;

        // Award money to offense based on distance traveled periodically
        float moneyForDistance = distanceTraveled * enemyData.moneyPerDistance;
        if (moneyForDistance > 0)
        {
            offenseFinance.AddToOffenseMoney(moneyForDistance);
            distanceTraveled = 0; // Reset distance counter after adding money
        }
    }
}
