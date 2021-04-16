using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerHitZone : IUpdateble
{
    public GameObject hitZonePrafab;
    private GameObject _hitZone;

    private Tower _parent;

    public void Initialize(Tower parent)
    {
        _parent = parent;
        SetHitZone();
    }

    public void EnableZone()
    {
        _hitZone.SetActive(true);
    }

    public void DesableZone()
    {
        _hitZone.SetActive(false);
    }

    private void SetHitZone()
    {
        _hitZone = InstantiateHitZone();
        SetHitZonePropertyes();
    }

    private GameObject InstantiateHitZone()
    {
        return Object.Instantiate(hitZonePrafab);
    }

    private void SetHitZonePropertyes()
    {
        float radius = _parent.towerData.Radius;

        _hitZone.transform.position = _parent.transform.position;

        _hitZone.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);

        _hitZone.transform.parent = _parent.transform;

        _hitZone.SetActive(false);
    }

    public void UpdateTower(TowerUpdater.TowerLevel level)
    {
        SetHitZonePropertyes();
    }
}
