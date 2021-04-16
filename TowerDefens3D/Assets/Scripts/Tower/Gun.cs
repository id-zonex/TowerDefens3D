using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "GunLV1")]
public class Gun : ScriptableObject, IUpdateble
{
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private float _coolDown = 0.5f;

    public float Damage 
    { 
        get { return _bulletPrefab.GetComponent<Bullet>().Damage; } 
        set { if(!(value <= 0)) _bulletPrefab.GetComponent<Bullet>().Damage = value; } 
    }

    public float CoolDown
    {
        get { return _coolDown; }
        set { if (!(value <= 0)) _coolDown = value; } 
    }

    private float _startTime;

    private int GetCurrentTimeInSeconds => (int)System.DateTime.Now.Subtract(new System.DateTime(2021, 1, 1)).TotalSeconds;

    public void UpdateTower(TowerUpdater.TowerLevel level)
    {
        Damage = level.Damage;
        CoolDown = level.CoolDown;
    }

    public void Shot(Transform position, Transform parent)
    {
        if (GetCurrentTimeInSeconds - _startTime > _coolDown)
        {
            Instantiate(_bulletPrefab, position.position, position.rotation, position);        
            _startTime = GetCurrentTimeInSeconds;
        }
    }
}
