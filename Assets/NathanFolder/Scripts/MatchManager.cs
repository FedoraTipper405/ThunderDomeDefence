using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public int RoundsCompleted;
    public int PlayerOneWins;
    public int PlayerTwoWins;
    public bool PlayerOneWinMatch;
    public bool MatchOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerOneWins >= 2)
        {
            MatchOver = true;
            PlayerOneWinMatch = true;
        }else if (PlayerTwoWins >= 2)
        {
            MatchOver = true;
            PlayerOneWinMatch = false;
        }
        {
            
        }
    }
}
