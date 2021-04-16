using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerUpdater
{
    [SerializeField] private TowerLevel[] _levels;

    public Tower parent { get; private set; }
    public int currentLevel { get; private set; } = 0;

    public void Initialize(Tower parent)
    {
        this.parent = parent;
    }

    public void Update()
    {
        if(!(currentLevel >= _levels.Length))
        {
            SetLevel(currentLevel);

            if (!(currentLevel >= _levels.Length))
                Money.SubtractMoney(_levels[currentLevel].updatePrice);

            parent.OpenTowerUI();
        }
        else
        {
            parent.isMaximumLevel = true;
        }

    }

    public void SetLevel(int level)
    {
        if(level <= _levels.Length)
        {
            (parent.towerData as IUpdateble).UpdateTower(_levels[level]);
            currentLevel++;
        }
    }

    [System.Serializable]
    public struct TowerLevel
    {
        public int Damage;
        public float CoolDown;
        public int Radius;

        public int updatePrice;
    }
}
