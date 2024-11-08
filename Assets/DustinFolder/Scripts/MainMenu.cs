using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Scene to load, set in the Inspector
    [SerializeField] GameData gameData;
    
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        gameData.ResetGame();
    }

    public void QuitGame()
    {
        // Quits the game when built
        Application.Quit();

        // Message for the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
