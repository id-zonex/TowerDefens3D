using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Tower : MonoBehaviour
{
    public TowerData towerData = new TowerData();
    public TowerUpdater towerUpdater = new TowerUpdater();
    public TowerHitZone towerHitZone = new TowerHitZone();
    public TowerReciplientEnemyes towerReciplientEnemyes = new TowerReciplientEnemyes();

    public bool isMaximumLevel = false;

    public List<EnemyControler> enemies { get; private set; } = new List<EnemyControler>();

    public static event UnityAction<Tower> OpenEvent;
    public static event UnityAction CloseEvent;

    public void UpdateTower()
    {
        towerUpdater.Update();
    }


    public void OpenTowerUI()
    {
        OpenEvent.Invoke(this);
    }
}
