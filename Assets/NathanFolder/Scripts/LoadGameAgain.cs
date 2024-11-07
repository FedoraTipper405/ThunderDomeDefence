using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameAgain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitToLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SampleScene");
    }
}
