using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isPlayerOne = true;
    bool gameIsSimulating = false;
    [SerializeField] PlayerOne pOne;
    [SerializeField] PlayerTwo pTwo;
    Vector2 mousePos;
    public GameState currentGameState;
    [SerializeField] GameObject continueButton;
    [SerializeField] OffensePurchaseManager offensePurchaseManager;
    [SerializeField] GameUIManager gameUIManager;
    [SerializeField] GameData gameData;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameState = GameState.PlayerOneTurn;
        if (gameData.PlayerOneDefense)
        {
            gameUIManager.isPlayerOneTurn = true;
        }
        else
        {
            gameUIManager.isPlayerOneTurn = false;
        }
        gameUIManager.UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ShowContinueButton(bool doShow)
    {
        continueButton.gameObject.SetActive(doShow);
    }
    public void ContinueToNextStage()
    {
        if(GameState.PlayerOneTurn == currentGameState)
        {
            currentGameState = GameState.PlayerTwoTurn;
            continueButton.gameObject.SetActive(false);
            gameUIManager.isDefenseTurn = false; 
            if (gameData.PlayerOneDefense)
            {
                gameUIManager.isPlayerOneTurn = false;
            }
            else
            {
                gameUIManager.isPlayerOneTurn = true;
            }
            gameUIManager.UpdateUI();
        }
        else if(GameState.PlayerTwoTurn == currentGameState)
        {
            currentGameState = GameState.Simulating;
            offensePurchaseManager.SpawnEnemies();
            continueButton.gameObject.SetActive(false);
        }
        else if(GameState.Simulating == currentGameState)
        {
            continueButton.gameObject.SetActive(true);
            currentGameState = GameState.PlayerOneTurn;
            gameUIManager.isDefenseTurn = true;
            if (gameData.PlayerOneDefense)
            {
                gameUIManager.isPlayerOneTurn = true;
            }
            else
            {
                gameUIManager.isPlayerOneTurn = false;
            }
            gameUIManager.IncrementWaveCounter();
            gameUIManager.UpdateUI();
        }
    }
    public void HandleMousePos(Vector2 pos)
    {
        mousePos = pos;
    }
    public void HandleMouseClicked()
    {
    if(currentGameState == GameState.PlayerOneTurn)
        {
            pOne.ClickOnSquare(mousePos);
        }
    }
   
}
public enum GameState
    {
    PlayerOneTurn = 0,
        PlayerTwoTurn = 1,
        Simulating = 2,

}
