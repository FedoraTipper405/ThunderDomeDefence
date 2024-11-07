using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int EnemiesSpawned = 0;
    public int Kills = 0;
    [SerializeField] PlayerController controller;
    void Start()
    {
        
    }
    public void ResetSim()
    {
        EnemiesSpawned = 0;
        Kills = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Kills >= EnemiesSpawned && controller.currentGameState == GameState.Simulating)
        {
            controller.ContinueToNextStage();
            ResetSim();
        }
    }
}
