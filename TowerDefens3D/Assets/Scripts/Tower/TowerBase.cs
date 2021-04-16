using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBase : MonoBehaviour
{
    public TowerData towerData;
    public TowerUpdater towerUpdater;

    public bool isMaximumLevel = false;

    protected List<EnemyControler> _enemies = new List<EnemyControler>();

    public void UpdateTower()
    {
        towerUpdater.Update();
    }
}
