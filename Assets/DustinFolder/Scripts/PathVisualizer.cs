using UnityEngine;

[ExecuteAlways] // Ensures the script runs in edit mode as well
public class PathVisualizer : MonoBehaviour
{
    [SerializeField] private bool showPath = true; // Toggle to show or hide the path
    [SerializeField] private Transform[] pathNodes; // Array of nodes defining the path
    [SerializeField] private Color lineColor = Color.cyan; // Colour of the gizmo lines
    [SerializeField] private float sphereSize = 0.2f; // Size of the gizmo spheres

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!showPath || pathNodes == null || pathNodes.Length < 2) return;

        // Draw lines and spheres between each path node
        for (int i = 0; i < pathNodes.Length - 1; i++)
        {
            if (pathNodes[i] != null && pathNodes[i + 1] != null)
            {
                Gizmos.color = lineColor;
                Gizmos.DrawLine(pathNodes[i].position, pathNodes[i + 1].position); // Draw line between nodes
                Gizmos.DrawSphere(pathNodes[i].position, sphereSize); // Draw sphere at each node
            }
        }

        // Draw sphere at the last node
        if (pathNodes[pathNodes.Length - 1] != null)
        {
            Gizmos.DrawSphere(pathNodes[pathNodes.Length - 1].position, sphereSize);
        }
    }
#endif
}
