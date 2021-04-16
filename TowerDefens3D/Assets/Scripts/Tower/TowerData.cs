using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerData : IUpdateble
{
    [SerializeField] private Gun _gun;
    [SerializeField] private int _price = 450;

    [SerializeField] private TargetingMode _targetingMode = TargetingMode.First;
    public int price => _price;

    public Tower parent { get; private set; }

    public TargetingMode TargetingMode { get => _targetingMode; private set => _targetingMode = value; }

    public float CoolDown => _gun.CoolDown;
    public float Radius => _sphere.radius;
    public Gun Gun => _gun;
    public string name => parent.name;

    private SphereCollider _sphere;

    public void Initialize(Tower parent)
    {
        this.parent = parent;

        _sphere = parent.GetComponent<SphereCollider>();
        _gun = Object.Instantiate(_gun);
    }

    public void UpdateTower(TowerUpdater.TowerLevel level)
    {
        _sphere.radius = level.Radius;
        (_gun as IUpdateble).UpdateTower(level);
    }

}
