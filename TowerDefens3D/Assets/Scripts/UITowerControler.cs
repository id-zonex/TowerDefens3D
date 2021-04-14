using UnityEngine;
using UnityEngine.UI;

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

    public void CloseTowerUIWindow()
    {
        _towerUIWindow.SetActive(false);
        if(_currentTower != null)
        {
            _currentTower.DesableZone();
        }
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

        TowerData towerData = tower.TowerData;
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

    public void Destroy()
    {
        if(_currentTower != null)
        {
            Money.AddMoney(_currentTower.TowerData.price / 2);
            Destroy(_currentTower.gameObject);

            CloseTowerUIWindow();
        }
    }
}
