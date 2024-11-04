using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float _bulletSpeed;
    [SerializeField] public float _bulletDamage;
    [SerializeField] public bool _canExplode;
    [SerializeField] public float _explosionSize;
    [SerializeField] public float _lifeSpan;

    private Transform _enemyTarget;
    public Vector2 startPosition;
    public Vector2 _lastenemyPosition;

    public void FollowTarget(Transform _target)
    {
        _enemyTarget = _target;
    }
    private void FixedUpdate()
    {
        Vector2 direction = (((_lastenemyPosition + (_lastenemyPosition - startPosition)) - (Vector2)transform.position).normalized);

        rb.linearVelocity = direction * _bulletSpeed;
        StartCoroutine(DestoryBullet());
    }

    IEnumerator DestoryBullet()
    {
        yield return new WaitForSeconds(_lifeSpan);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_canExplode)
            {
                ExplodingBullet();
            }
            Destroy(collision.transform.gameObject);
            Destroy(gameObject);
        }
    }

    private void ExplodingBullet()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _explosionSize);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                Destroy(enemy.transform.gameObject);
            }
        }
    }
}
