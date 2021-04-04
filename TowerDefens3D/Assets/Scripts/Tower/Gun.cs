using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "GunLV1")]
public class Gun : ScriptableObject
{
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private float _coolDown = 0.5f;

    public float Damage => _bulletPrefab.GetComponent<Bullet>().Damage;

    public float CoolDown 
    { 
        get { return _coolDown; }
        set { if (!(value <= 0)) _coolDown = value;  }
    }

    private float _startTime;

    private int GetCurrentTimeInSeconds => (int)System.DateTime.Now.Subtract(new System.DateTime(2021, 1, 1)).TotalSeconds;

    public void Shot(Transform position, Transform parent)
    {
        if (GetCurrentTimeInSeconds - _startTime > _coolDown)
        {
            Instantiate(_bulletPrefab.gameObject, position.position, position.rotation, position);
           
            _startTime = GetCurrentTimeInSeconds;
        }
    }
}
