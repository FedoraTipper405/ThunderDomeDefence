using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] private List<Transform> pathNodes = new List<Transform>(); // Nodes defining the path for enemies
    [SerializeField] private float speed; // Speed of the enemy unit
    private float startDelay = 0f; // Delay before an enemy starts moving
    private float health;
    public List<EnemyMovement> enemyList = new List<EnemyMovement>(); // List for enemies waiting to start
    
    SimulationManager simManager;
    OffenseFinance offenseFinance;
    DefenseFinance defenseFinance;
    DefenseHealth defenseHealth;
    private int currentNodeIndex = 0;
    private bool isMoving = false;
    private bool findingNodes = true;
    private int indexOfNode = 1;
    private void Awake()
    {
        health = enemyData.health;
       
        // Hide path nodes in-game but keep them visible in the editor
        foreach (Transform node in pathNodes)
        {
            if (node != null)
            {
                node.gameObject.SetActive(false);
            }
        }
        if (NodeManager.Instance != null)
        {
            pathNodes = NodeManager.Instance.NodeList;
            simManager = NodeManager.Instance.simManager;
            offenseFinance = NodeManager.Instance.offenseFinance;
            defenseFinance = NodeManager.Instance.defenseFinance;
            defenseHealth = NodeManager.Instance.defenseHealth;
        }//// Add this enemy to the list
         //enemyList.Insert(0,this);

        //// Sort the list based on startDelay in ascending order
        //enemyList = enemyList.OrderBy(enemy => enemy.startDelay).ToList();

        //// Start checking the list
        //if (enemyList[0] == this)
        //{
        Invoke(nameof(StartMoving), startDelay);
        //}
    }

    private void Update()
    {
        if (!isMoving || pathNodes.Count < 2) return; // Ensure there is a valid path with at least two nodes and the enemy is allowed to move

        if(transform.position.x <= -10)
        {
            speed = 2;
        }
        else
        {
            speed = enemyData.speed;
        }
        MoveTowards(pathNodes[currentNodeIndex].position);

        // Check if the enemy reached the current node
        if (Vector3.Distance(transform.position, pathNodes[currentNodeIndex].position) < 0.1f)
        {
            currentNodeIndex++;

            // Check if the enemy has reached the last node
            if (currentNodeIndex >= pathNodes.Count)
            {
                OnReachedEnd();
            }
        }
    }
    public void ReduceHealth(float damage)
    {
        if(transform.position.x > -10)
        {
            health -= damage;
        }
        if(health <= 0)
        {
            defenseFinance.AddToDefenderMoney(enemyData.moneyForKill);
            Destroy(gameObject);
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
        offenseFinance.AddToOffenseMoney(enemyData.rewardForReachingEnd);
        defenseHealth.TakeDamage(enemyData.damage);
        defenseHealth.UpdateWallHealthText();
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
    private void OnDestroy()
    {
        simManager.Kills++;
    }
}
