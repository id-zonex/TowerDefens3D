using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerReciplientEnemyes : IUpdateble
{
    private Tower _parent;

    public void Initialize(Tower parent)
    {
        _parent = parent;
    }

    public void UpdateTower(TowerUpdater.TowerLevel level)
    {
    }

    public void RemoveEnemy(EnemyControler enemy)
    {
        _parent.enemies.Remove(enemy);
    }

    public EnemyControler ParseEnemy(GameObject gameObject)
    {
        return gameObject.GetComponent<EnemyControler>();
    }

    public EnemyControler GetCurrentEnemy()
    {
        switch (_parent.towerData.TargetingMode)
        {
            case TargetingMode.First:
                return TryGetFirstEnemy();
            case TargetingMode.Last:
                return _parent.enemies[_parent.enemies.Count - 1];
            default:
                return TryGetFirstEnemy();
        }
    }

    public EnemyControler TryGetFirstEnemy()
    {
        for (int i = 0; i < _parent.enemies.Count; i++)
        {
            EnemyControler enemy = _parent.enemies[i];

            if (enemy != null)
            {
                return enemy;
            }
        }

        return null;
    }
}
