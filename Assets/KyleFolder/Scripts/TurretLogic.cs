using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] public bool _sniperFire => _turretData._sniperMode;
    [SerializeField] public int _soundEffect => _turretData._soundEffect;

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
            if (canFire && _sniperFire == false)
            {
                StartCoroutine(CanShoot());
            }
            if (canFire && _sniperFire)
            {
                StartCoroutine(CanShootSniper());
            }
        }
    }

    IEnumerator CanShootSniper()
    {
        canFire = false;
        SniperFireMode();
        yield return new WaitForSeconds(_timeBetweenShots);
        canFire = true;
    }
    IEnumerator ShowLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(0.1f);
        laserLine.enabled = false;
    }

    IEnumerator CanShoot()
    {
        canFire = false;
        Shoot();
        yield return new WaitForSeconds(_timeBetweenShots);
        canFire = true;
    }

    private void SniperFireMode()
    {
        laserLine.SetPosition(0, _firingPoint.position);
        laserLine.SetPosition(1, _enemytarget.position);
        StartCoroutine(ShowLaser());
        _enemytarget.gameObject.GetComponent<EnemyMovement>().ReduceHealth(_turretData._bulletDamage);
        AudioManager.PlaySound(_soundEffect);
        // Destroy(_enemytarget.gameObject);
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
        AudioManager.PlaySound(_soundEffect);
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
}
