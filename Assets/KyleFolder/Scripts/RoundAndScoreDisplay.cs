using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundAndScoreDisplay : MonoBehaviour
{
    [SerializeField] GameData gameData;
    
    public TMP_Text roundText;
    public TMP_Text playerOneScoreText;
    public TMP_Text playerTwoScoreText;
    void Start()
    {
        roundText.text = "Round: " + gameData.Round.ToString();
        playerOneScoreText.text = "PlayerOneScore: " + gameData.PlayerOneScore.ToString();
        playerTwoScoreText.text = "PlayerTwoScore: " + gameData.PlayerTwoScore.ToString();
    }

}
