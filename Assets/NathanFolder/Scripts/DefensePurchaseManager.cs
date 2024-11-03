using System.Collections;
using UnityEngine;

public class DefensePurchaseManager : MonoBehaviour
{
    int defenseMoney = 100;
    GameObject currentSelectedSquare;
    bool menuIsOpen = false;
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
        currentSelectedSquare.transform.parent.GetChild(towerIndex).gameObject.SetActive(true);
        currentSelectedSquare.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}