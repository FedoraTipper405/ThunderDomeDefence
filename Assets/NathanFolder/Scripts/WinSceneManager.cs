using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadMainMenu());
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
