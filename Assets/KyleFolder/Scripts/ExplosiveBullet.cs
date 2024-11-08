using System.Collections;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public int _soundEffect = 9;
    void Start()
    {
        StartCoroutine(DeleteAfterExoplosion());
    }
    IEnumerator DeleteAfterExoplosion()
    {
        AudioManager.PlaySound(_soundEffect);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
