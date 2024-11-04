using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] pathNodes; // Nodes defining the path for enemies
    [SerializeField] private float speed = 2f; // Speed of the enemy unit
    [SerializeField] private float startDelay = 1f; // Delay before an enemy starts moving

    private static List<EnemyMovement> enemyList = new List<EnemyMovement>(); // List for enemies waiting to start
    private int currentNodeIndex = 0;
    private bool isMoving = false;

    private void Start()
    {
        // Hide path nodes in-game but keep them visible in the editor
        foreach (Transform node in pathNodes)
        {
            if (node != null)
            {
                node.gameObject.SetActive(false);
            }
        }

        // Add this enemy to the list
        enemyList.Add(this);

        // Sort the list based on startDelay in ascending order
        enemyList = enemyList.OrderBy(enemy => enemy.startDelay).ToList();

        // Start checking the list
        if (enemyList[0] == this)
        {
            Invoke(nameof(StartMoving), startDelay);
        }
    }

    private void Update()
    {
        if (!isMoving || pathNodes.Length < 2) return; // Ensure there is a valid path with at least two nodes and the enemy is allowed to move

        MoveTowards(pathNodes[currentNodeIndex].position);

        // Check if the enemy reached the current node
        if (Vector3.Distance(transform.position, pathNodes[currentNodeIndex].position) < 0.1f)
        {
            currentNodeIndex++;

            // Check if the enemy has reached the last node
            if (currentNodeIndex >= pathNodes.Length)
            {
                OnReachedEnd();
            }
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        // Move towards the target node position
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void OnReachedEnd()
    {
        Debug.Log("Enemy reached the end!");
        Destroy(gameObject);
    }

    private void StartMoving()
    {
        isMoving = true;
        enemyList.Remove(this); // Remove this enemy from the list

        // Start the next enemy in the list, if any
        if (enemyList.Count > 0)
        {
            EnemyMovement nextEnemy = enemyList[0];
            nextEnemy.Invoke(nameof(StartMoving), nextEnemy.startDelay);
        }
    }
}
