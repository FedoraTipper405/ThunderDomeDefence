using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "SOs/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Stats")]

    public float health; // Health of the enemy
    public float speed; // Speed of the enemy
    public int damage;

    [Header("Rewards")]
    public int moneyForKill; // Money rewarded for killing the enemy
    public float moneyPerDistance; // Money awarded per unit distance traveled
    public int unitCost;
    public int rewardForReachingEnd;
}
