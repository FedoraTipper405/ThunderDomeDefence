using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "SOs/GameData")]
public class GameData : ScriptableObject
{
    public bool PlayerOneDefense;
    public bool PlayerTwoDefense;
    public int PlayerOneScore;
    public int PlayerTwoScore;
    public int Round;
    public bool PlayerOneWon;
    public void ResetGame()
    {
        PlayerOneDefense = true;
        PlayerTwoDefense = false;
        PlayerOneScore = 0;
        PlayerTwoScore = 0;
        Round = 1;
    }
}
