using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OffensePurchaseManager : MonoBehaviour
{
    [SerializeField] GameObject AgilePrefab;
    [SerializeField] GameObject RegularPrefab;
    [SerializeField] GameObject HeavyPrefab;
    [SerializeField] GameObject BusPrefab;

    [SerializeField] EnemyData AgileData;
    [SerializeField] EnemyData RegularData;
    [SerializeField] EnemyData HeavyData;
    [SerializeField] EnemyData BusData;
    [SerializeField] OffenseFinance finance;

    [SerializeField] List<GameObject> spawnQueue = new List<GameObject>();
    [SerializeField] List<EnemyMovement> tempEnemyList = new List<EnemyMovement>();
    [SerializeField] Transform spawnLocation;
    [SerializeField] PlayerController playerController;
    [SerializeField] SimulationManager simulationManager;
    [SerializeField] TMP_Text enemyList;
    [SerializeField] WinManager winManager;
    [SerializeField] GameUIManager gameUIManager;
    string enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void AddToEnemyPool(int enemyIndex)
    {
    
        if (enemyIndex == ((int)EnemyType.Agile) && finance.offenseMoney >= AgileData.unitCost)
        {
            spawnQueue.Add(AgilePrefab);
            finance.TakeAwayOffenseMoney(AgileData.unitCost);
        }
        else if (enemyIndex == ((int)EnemyType.Regular) && finance.offenseMoney >= RegularData.unitCost)
        {
            spawnQueue.Add(RegularPrefab);
            finance.TakeAwayOffenseMoney(RegularData.unitCost);
        }
        else if (enemyIndex == ((int)EnemyType.Heavy) && finance.offenseMoney >= HeavyData.unitCost)
        {
            spawnQueue.Add(HeavyPrefab);
            finance.TakeAwayOffenseMoney(HeavyData.unitCost);
        }
        else if (enemyIndex == ((int)EnemyType.Bus) && finance.offenseMoney >= BusData.unitCost)
        {
            spawnQueue.Add(BusPrefab);
            finance.TakeAwayOffenseMoney(BusData.unitCost);
        }
        GenerateListDisplay();
        gameUIManager.UpdateUI();
    }
    public void GenerateListDisplay()
    {
        Debug.Log("TryToGenerate");
        enemies = "";
        int numberOfType = 0;
       // GameObject lastInList = null;
        for(int i = 0; i < spawnQueue.Count; i++)
        {
            if(i == 0)
            {
                numberOfType++;
                Debug.Log(numberOfType);
            }else if (spawnQueue[i].name == spawnQueue[i-1].name)
            {
                numberOfType++;
                Debug.Log(numberOfType);
            }
            else if (spawnQueue[i].name != spawnQueue[i-1].name )    
            {
                if (spawnQueue[i-1].name == AgilePrefab.name)
                {
                    enemies += " MR:";
                }
                else if (spawnQueue[i-1].name == RegularPrefab.name)
                {
                    enemies += " RC:";
                }
                else if (spawnQueue[i-1].name == HeavyPrefab.name)
                {
                    enemies += " B:";
                }
                else if (spawnQueue[i-1].name == BusPrefab.name)
                {
                    enemies += " PB:";
                }
                enemies += numberOfType.ToString();
                numberOfType = 1;
                Debug.Log(numberOfType);
            }
            if(i == spawnQueue.Count-1)
            {
                if (spawnQueue[i].name == AgilePrefab.name)
                {
                    enemies += " MR:";
                }
                else if (spawnQueue[i].name == RegularPrefab.name)
                {
                    enemies += " RC:";
                }
                else if (spawnQueue[i].name == HeavyPrefab.name)
                {
                    enemies += " B:";
                }
                else if (spawnQueue[i].name == BusPrefab.name)
                {
                    enemies += " PB:";
                }
                enemies += numberOfType.ToString();
            }
        }
        enemyList.SetText(enemies);
        Debug.Log(enemies);
    }
    public void RemoveLastOfType(int enemyIndex)
    {

        int removeAtThis = 0;
        bool foundToDelete = false;
        bool hasReturnedMoney = false;
        for(int i = 0 ; i < spawnQueue.Count; i++)
        {
            if(enemyIndex == (int)EnemyType.Agile)
            {
                if (spawnQueue[i].name == "AgileEnemy")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                    if(!hasReturnedMoney)
                    {
                        finance.AddToOffenseMoney(AgileData.unitCost);
                        hasReturnedMoney = true;
                    }
                    
                }
            }
            if (enemyIndex == (int)EnemyType.Regular)
            {
                if (spawnQueue[i].name == "RegularEnemy")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                    if (!hasReturnedMoney)
                    {
                        finance.AddToOffenseMoney(RegularData.unitCost);
                        hasReturnedMoney = true;
                    }
                    
                }
            }
            if (enemyIndex == (int)EnemyType.Heavy)
            {
                if (spawnQueue[i].name == "HeavyEnemy")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                    if (!hasReturnedMoney)
                    {
                        finance.AddToOffenseMoney(HeavyData.unitCost);
                        hasReturnedMoney = true;
                    }
                   
                }
            }
            if (enemyIndex == (int)EnemyType.Bus)
            {
                if (spawnQueue[i].name == "BusEnemy")
                {
                    removeAtThis = i;
                    foundToDelete = true;
                    if (!hasReturnedMoney)
                    {
                        finance.AddToOffenseMoney(BusData.unitCost);
                        hasReturnedMoney = true;
                    }
                    
                }
            }

        }
        if(foundToDelete)
        {
            spawnQueue.RemoveAt(removeAtThis);
        }
        GenerateListDisplay();
        gameUIManager.UpdateUI();
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
        spawnQueue.Clear();
    }
    public void ClearAll()
    {
        for (int i = 0 ;i < spawnQueue.Count; i++)
        {
            if (spawnQueue[i].name == AgilePrefab.name)
            {
                finance.AddToOffenseMoney(AgileData.unitCost);
            }
            else if (spawnQueue[i].name == RegularPrefab.name)
            {
                finance.AddToOffenseMoney(RegularData.unitCost);
            }
            else if (spawnQueue[i].name == HeavyPrefab.name)
            {
                finance.AddToOffenseMoney(HeavyData.unitCost);

            }
            else if (spawnQueue[i].name == BusPrefab.name)
            {
                finance.AddToOffenseMoney(BusData.unitCost);

            }
        }
        spawnQueue.Clear();
        GenerateListDisplay();
        gameUIManager.UpdateUI();
    }
    // Update is called once per frame
    void Update()
    {
        if (finance.offenseMoney < RegularData.unitCost && spawnQueue.Count == 0 && playerController.currentGameState == GameState.PlayerTwoTurn)
        {
            winManager.DefenseWins();
            winManager.NextRound();
        }
        if (spawnQueue.Count <= 0 && playerController.currentGameState == GameState.PlayerTwoTurn)
        {
            playerController.ShowContinueButton(false);
        }
        else if(spawnQueue.Count >= 0 && playerController.currentGameState == GameState.PlayerTwoTurn)
        {
            playerController.ShowContinueButton(true);
        }
        if(playerController.currentGameState != GameState.PlayerTwoTurn)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
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