using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TurretLogic : MonoBehaviour
{
    [SerializeField] private TurretData _turretData;
    [SerializeField] private float _targetingRange => _turretData._targetingRange;
    [SerializeField] private float _timeBetweenShots => _turretData._timeBetweenShots;
    [SerializeField] private GameObject _bulletPrefab => _turretData._bulletPrefab;
    [SerializeField] public float _bulletAccuracy => _turretData._bulletAccuracy;
    [SerializeField] public bool _canExplode => _turretData._canExplode;
    [SerializeField] public bool _alt => _turretData._altFire;

    [SerializeField] private Transform _turretRotation;
    [SerializeField] private Transform _firingPoint;
    [SerializeField] private LayerMask _enemyLayer;
    LineRenderer laserLine;

    private Transform _enemytarget;
    private bool canFire = true;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled = false;
    }

    private void FixedUpdate()
    {
        if (_enemytarget == null)
        {
            FindTarget();
            return;
        }

        RotateAtTarget();
        if (!CheckTargetIsInRange())
        {
            _enemytarget = null;
        }
        else
        {
            if (canFire && _alt == false)
            {
                StartCoroutine(CanShoot());
            }
            if (canFire && _alt)
            {
                StartCoroutine(CanShootAlt());
            }
        }
    }

    IEnumerator CanShootAlt()
    {
        canFire = false;
        AltFireMode();
        yield return new WaitForSeconds(_timeBetweenShots);
        canFire = true;
    }

    IEnumerator CanShoot()
    {
        canFire = false;
        Shoot();
        yield return new WaitForSeconds(_timeBetweenShots);
        canFire = true;
    }

    private void AltFireMode()
    {
        RaycastHit2D hit = Physics2D.Raycast(_firingPoint.position, _enemytarget.position - _firingPoint.position);
        if (hit.collider != null)
        {
            laserLine.SetPosition(0, _firingPoint.position);
            laserLine.SetPosition(1, _enemytarget.position);
            laserLine.enabled = true;
            Destroy(hit.transform.gameObject);
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firingPoint.position, Quaternion.identity);
        BulletLogic bulletScript = bullet.GetComponent<BulletLogic>();
        bulletScript._bulletSpeed = _turretData._bulletSpeed;
        bulletScript._bulletDamage = _turretData._bulletDamage;
        bulletScript._canExplode = _turretData._canExplode;
        bulletScript._lastenemyPosition = (Vector2)_enemytarget.position + new Vector2(Random.Range(-_bulletAccuracy, _bulletAccuracy), Random.Range(-_bulletAccuracy, _bulletAccuracy));
        bulletScript.startPosition = (Vector2)transform.position;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _targetingRange, (Vector2)transform.position, 0f, _enemyLayer);

        if (hits.Length > 0)
        {
            _enemytarget = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(_enemytarget.position, transform.position) <= _targetingRange;
    }

    private void RotateAtTarget()
    {
        float angle = Mathf.Atan2(_enemytarget.position.y - transform.position.y, _enemytarget.position.x - transform.position.x) * Mathf.Rad2Deg + -90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        _turretRotation.rotation = targetRotation;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, _targetingRange);
    }
}
