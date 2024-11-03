using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    [SerializeField] DefensePurchaseManager defensePurchaseManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    public void ClickOnSquare(Vector2 mousePos)
    {
        Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(mousePos);
        Collider2D[] col = Physics2D.OverlapPointAll(mouseScreenPos);
        for(int i = 0; i < col.Length; i++)
        {
            if (col[i].gameObject.tag == "EmptySquare")
            {
                defensePurchaseManager.SelectedSquare(col[i].gameObject);
            }
        }
    }
}
