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

    private Tower _currentTower;

    private void Awake()
    {
        Tower.OpenEvent += SetTowerUI;
        Tower.CloseEvent += CloseTowerUIWindow;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = CamersControler.currentCamera.mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Tower tower = GetTower(hit);

                if (tower != null)
                {
                    tower.OpenTowerUI();
                }
                else if(!EventSystem.current.IsPointerOverGameObject())
                {
                    CloseTowerUIWindow();
                }
            }
        }
    }

    public void CloseTowerUIWindow()
    {
        _towerUIWindow.SetActive(false);
        if(_currentTower != null)
        {
            _currentTower.DesableZone();
        }
    }

    private Tower GetTower(RaycastHit hit)
    {
        return hit.collider.GetComponentInParent<Tower>();
    }

    private void OpenTowerUIWindow()
    {
        _towerUIWindow.SetActive(true);
    }

    private void SetTowerUI(Tower tower)
    {
        CloseTowerUIWindow();

        OpenTowerUIWindow();
        tower.EnableZone();

        TowerData towerData = tower.towerData;
        _currentTower = tower;

        SetTowerUIText(towerData);
    }

    private void SetTowerUIText(TowerData towerData)
    {
        _towerName.text = towerData.name;
        _towerDamage.text = "Dmg: " + towerData.Gun.Damage.ToString();
        _towerCoolDown.text = "Spa: " + towerData.Gun.CoolDown.ToString();
        _towerRadius.text = "Rng: " + ((int)towerData.Radius).ToString();
    }

    public void UpdateTower()
    {
        _currentTower?.towerUpdater.Update();
    }

    public void Destroy()
    {
        if(_currentTower != null)
        {
            Money.AddMoney(_currentTower.towerData.price / 2);
            Destroy(_currentTower.gameObject);

            CloseTowerUIWindow();
        }
    }
}
