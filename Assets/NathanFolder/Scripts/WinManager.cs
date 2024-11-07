using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void DefenseWins()
    {
        if (gameData.PlayerOneDefense)
        {
            gameData.PlayerOneScore++;
        }
        else
        {
            gameData.PlayerTwoScore++;
        }
    }
    public void OffenseWins()
    {
        if (!gameData.PlayerOneDefense)
        {
            gameData.PlayerOneScore++;
        }
        else
        {
            gameData.PlayerTwoScore++;
        }
    }
    public void NextRound()
    {
        gameData.PlayerOneDefense = !gameData.PlayerOneDefense;
        gameData.PlayerTwoDefense = !gameData.PlayerTwoDefense;
        gameData.Round++;
        SceneManager.LoadScene("BetweenRounds");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
