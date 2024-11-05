using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensePurchaseManager : MonoBehaviour
{
    [SerializeField] GameObject AgilePrefab;
    [SerializeField] GameObject RegularPrefab;
    [SerializeField] GameObject HeavyPrefab;
    [SerializeField] GameObject BusPrefab;
    [SerializeField] List<GameObject> spawnQueue = new List<GameObject>();
    [SerializeField] List<EnemyMovement> tempEnemyList = new List<EnemyMovement>();
    [SerializeField] Transform spawnLocation;
    [SerializeField] PlayerController playerController;
    [SerializeField] SimulationManager simulationManager;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void AddToEnemyPool(int enemyIndex)
    {
        if(enemyIndex == ((int)EnemyType.Agile))
        {
            spawnQueue.Add(AgilePrefab);
        }
        else if (enemyIndex == ((int)EnemyType.Regular))
        {
            spawnQueue.Add(RegularPrefab);
        }
        else if (enemyIndex == ((int)EnemyType.Heavy))
        {
            spawnQueue.Add(HeavyPrefab);
        }
        else if (enemyIndex == ((int)EnemyType.Bus))
        {
            spawnQueue.Add(BusPrefab);
        }
    }
    public void RemoveLastOfType(int enemyIndex)
    {
        int removeAtThis = 0;
        bool foundToDelete = false;
        for(int i = 0 ; i < spawnQueue.Count; i++)
        {
            if(enemyIndex == (int)EnemyType.Agile)
            {
                if (spawnQueue[i].name == "AgilePrefab")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                }
            }
            if (enemyIndex == (int)EnemyType.Regular)
            {
                if (spawnQueue[i].name == "RegularPrefab")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                }
            }
            if (enemyIndex == (int)EnemyType.Heavy)
            {
                if (spawnQueue[i].name == "HeavyPrefab")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                }
            }
            if (enemyIndex == (int)EnemyType.Bus)
            {
                if (spawnQueue[i].name == "BusPrefab")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                }
            }

        }
        if(foundToDelete)
        {
            spawnQueue.RemoveAt(removeAtThis);
        }
        
    }
    public void SpawnEnemies()
    {
        StartCoroutine(SpawnDelay());
        
    }
    IEnumerator SpawnDelay()
    {
        for (int i = 0 ; i < spawnQueue.Count; i++)
        {
            GameObject lastSpawnedEnemy = Instantiate(spawnQueue[i], spawnLocation.position, Quaternion.identity);
            simulationManager.EnemiesSpawned++;
            yield return new WaitForSeconds(1);
        }
    }
    public void ClearAll()
    {
        spawnQueue.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemies();
        }
        if(playerController.currentGameState != GameState.PlayerTwoTurn)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}


public enum EnemyType
{
    Agile = 0,
    Regular = 1,
    Heavy = 2,
    Bus = 3
}