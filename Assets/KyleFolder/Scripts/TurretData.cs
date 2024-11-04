using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "SOs/TurretData")]
public class TurretData : ScriptableObject
{
    [SerializeField] public float _targetingRange;
    [SerializeField] public float _timeBetweenShots;
    [SerializeField] public float _bulletDamage;
    [SerializeField] public float _bulletSpeed;
    [SerializeField] public float _bulletAccuracy;
    [SerializeField] public bool _canExplode;
    [SerializeField] public bool _altFire;
    [SerializeField] public GameObject _bulletPrefab;
}
