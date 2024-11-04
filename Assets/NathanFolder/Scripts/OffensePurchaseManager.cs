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
    public enum EnemyType
    {
        Agile = 0,
        Regular = 1,
        Heavy = 2,
        Bus = 3
    }
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
    public void ClearAll()
    {
        spawnQueue.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
