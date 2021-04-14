using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerData : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    [SerializeField] private int _price = 450;
    public int price => _price;

    public TargetingMode TargetingMode = TargetingMode.First;
    public float CoolDown => _gun.CoolDown;
    public float Radius => sphere.radius;
    public Gun Gun => _gun;

    private SphereCollider sphere;

    public void Awake()
    {
        sphere = GetComponent<SphereCollider>();
        _gun = Object.Instantiate(_gun);
    }
}
