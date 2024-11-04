using UnityEngine;

public class EnemyTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }
    }
}
