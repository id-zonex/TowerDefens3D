using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(SphereCollider))]
public class TowerType1 : Tower
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _trunk;

    #region Unity 
    private void Awake()
    {
        towerUpdater.Initialize(this);
        towerData.Initialize(this);
        towerHitZone.Initialize(this);
        towerReciplientEnemyes.Initialize(this);

        towerUpdater.SetLevel(0);
    }

    private void FixedUpdate()
    {
        EnemyControler target;

        if (enemies.Count > 0)
        {
            target = towerReciplientEnemyes.GetCurrentEnemy();

            if(target != null)
            {
                Rotate(target);

                towerData.Gun.Shot(_trunk, transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyControler enemy = towerReciplientEnemyes.ParseEnemy(other.gameObject);

        if (enemy != null)
            enemies.Add(towerReciplientEnemyes.ParseEnemy(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyControler enemy = towerReciplientEnemyes.ParseEnemy(other.gameObject);

        if(enemy != null)
           towerReciplientEnemyes.RemoveEnemy(towerReciplientEnemyes.ParseEnemy(other.gameObject));
    }

    #endregion

    #region Move
    private void Rotate(EnemyControler target)
    {
        float Ypos = Mathf.Clamp(target.transform.position.y, 0.2f, 3);

        _head.LookAt(new Vector3(target.transform.position.x, _head.position.y, target.transform.position.z));
        _trunk.LookAt(new Vector3(target.transform.position.x, Ypos, target.transform.position.z));
    }

    #endregion
}
