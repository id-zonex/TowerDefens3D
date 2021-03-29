using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour
{
    [SerializeField] private Image _hpBar;

    private EnemyControler _parent;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;

        _parent = gameObject.GetComponentInParent<EnemyControler>();

        _parent.DamagedEvent += OnDamaged;
    }

    private void OnDamaged(float currentHealth, float maxHealth)
    {
        _hpBar.fillAmount = currentHealth / maxHealth;
    }
}
