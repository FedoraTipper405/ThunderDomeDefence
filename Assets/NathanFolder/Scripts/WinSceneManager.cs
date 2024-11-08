using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] GameObject playerOneWinText;
    [SerializeField] GameObject playerTwoWinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadMainMenu());
        if(gameData.PlayerOneWon == true)
        {
            playerOneWinText.SetActive(true);
        }
        else if (gameData.PlayerOneWon == false)
        {
            playerTwoWinText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5);
        gameData.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }
}
