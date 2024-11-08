using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundAndScoreDisplay : MonoBehaviour
{
    [SerializeField] GameData gameData;

    public GameObject[] Animatedround;
    public TMP_Text playerOneScoreText;
    public TMP_Text playerTwoScoreText;
    void Start()
    {
        playerOneScoreText.text = "PlayerOneScore: " + gameData.PlayerOneScore.ToString();
        playerTwoScoreText.text = "PlayerTwoScore: " + gameData.PlayerTwoScore.ToString();
        
        if(gameData.Round == 1)
        {
            Animatedround[0].SetActive(true);
        }
        else if (gameData.Round == 2)
        {
            Animatedround[1].SetActive(true);
        }
        else if (gameData.Round == 3)
        {
            Animatedround[2].SetActive(true);
        }
    }

}
