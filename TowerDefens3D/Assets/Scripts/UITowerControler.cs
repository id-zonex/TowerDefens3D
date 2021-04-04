using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITowerControler : MonoBehaviour
{
    [SerializeField] private GameObject _towerUIWindow;

    [SerializeField] private Text _towerName;
    [SerializeField] private Text _towerDamage;
    [SerializeField] private Text _towerCoolDown;
    [SerializeField] private Text _towerRadius;


    [SerializeField] private LayerMask _layerMask;

    private TowerData _currentTower;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = CamersControler.MainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _layerMask))
            {
                OpenTowerUIWindow();

                TowerData towerData = hit.collider.gameObject.GetComponentInParent<TowerData>();
                Tower tower = hit.collider.gameObject.GetComponentInParent<Tower>();

                if (towerData != null)
                {
                    _currentTower?.GetComponent<Tower>().DesableZone();

                    SetTowerUI(towerData);
                    tower.EnableZone();
                }
                else if (!EventSystem.current.IsPointerOverGameObject())
                {
                    CloseTowerUIWindow();
                    _currentTower?.GetComponent<Tower>().DesableZone();
                }
            }
        }
    }

    private void CloseTowerUIWindow()
    {
        _towerUIWindow.SetActive(false);
    }

    private void OpenTowerUIWindow()
    {
        _towerUIWindow.SetActive(true);
    }

    private void SetTowerUI(TowerData tower)
    {
        _currentTower = tower;

        _towerName.text = tower.name;
        _towerDamage.text = "Dmg: " + tower.Gun.Damage.ToString();
        _towerCoolDown.text = "Spa: " + tower.Gun.CoolDown.ToString();
        _towerRadius.text = "Rng: " + ((int)tower.Radius).ToString();
    }

    public void Destroy()
    {
        if(_currentTower != null)
        {
            Destroy(_currentTower.gameObject);

            CloseTowerUIWindow();
        }
    }
}
