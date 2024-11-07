
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : Singleton<NodeManager>
{
    public List<Transform> NodeList = new();
    public SimulationManager simManager;
    public DefenseFinance defenseFinance;
    public OffenseFinance offenseFinance;
    public DefenseHealth defenseHealth;
}
