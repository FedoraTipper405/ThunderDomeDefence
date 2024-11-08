using TMPro;
using UnityEngine;

public class DefenseHealth : MonoBehaviour
{
    public int WallHealth;
    [SerializeField] TMP_Text wallHealthText;
    [SerializeField] WinManager winManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void TakeDamage(int damage)
    {
        WallHealth -= damage;
        if (WallHealth <= 0 )
        {
            winManager.OffenseWins();
            winManager.NextRound();
        }
    }
    public void UpdateWallHealthText()
    {
        wallHealthText.SetText(WallHealth.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
