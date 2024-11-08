using System.Collections;
using UnityEngine;

public class DefensePurchaseManager : MonoBehaviour
{
   // int defenseMoney = 100;
    GameObject currentSelectedSquare;
    bool menuIsOpen = false;
    [SerializeField] GameObject[] towerPrefabs;
    [SerializeField] TurretData[] towerData;
    [SerializeField] PlayerController playerController;
    [SerializeField] DefenseFinance defenseFinance;
    [SerializeField] GameUIManager gameUIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void SelectedSquare(GameObject selectedSquare)
    {
        if (!menuIsOpen)
        {
            StartCoroutine(StopMultiClick(selectedSquare));
        }
       
    }
    IEnumerator StopMultiClick(GameObject selectedSquare)
    {
        menuIsOpen = true;
         yield return new WaitForSeconds(.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        currentSelectedSquare = selectedSquare;
    }

    public void ClosePurchaseMenu()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        menuIsOpen = false;
    }
    public void PurchaseTowerType(int towerIndex)
    {
        if (towerData[towerIndex-1]._towerCost <= defenseFinance.defenseMoney)
        {
            GameObject towerToSpawn = Instantiate(towerPrefabs[towerIndex - 1], currentSelectedSquare.transform.position, Quaternion.identity);
            defenseFinance.RemoveDefenderMoney(towerData[towerIndex-1]._towerCost);
            currentSelectedSquare.gameObject.SetActive(false);
            gameUIManager.UpdateUI();
        }
       
       // currentSelectedSquare.transform.parent.GetChild(towerIndex).gameObject.SetActive(true);
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
