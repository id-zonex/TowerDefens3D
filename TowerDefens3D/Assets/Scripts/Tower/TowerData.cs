using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    public TargetingMode TargetingMode = TargetingMode.First;
    public float CoolDown => _gun.CoolDown;
    public float Radius => GetComponent<SphereCollider>().radius;
    public Gun Gun => _gun;

    private void Awake()
    {
        _gun = Instantiate(_gun);
    }
}
