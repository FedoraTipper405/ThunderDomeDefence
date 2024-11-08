using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "SOs/GameData")]
public class GameData : ScriptableObject
{
    public bool PlayerOneDefense;
    public bool PlayerTwoDefense;
    public int PlayerOneScore;
    public int PlayerTwoScore;
    public int Round;
}
