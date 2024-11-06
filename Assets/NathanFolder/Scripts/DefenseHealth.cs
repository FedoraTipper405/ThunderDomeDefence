using TMPro;
using UnityEngine;

public class DefenseHealth : MonoBehaviour
{
    public int WallHealth;
    [SerializeField] TMP_Text wallHealthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void TakeDamage(int damage)
    {
        WallHealth -= damage;
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
