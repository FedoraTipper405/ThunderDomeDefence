using System.Collections;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DeleteAfterExoplosion());
    }
    IEnumerator DeleteAfterExoplosion()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
