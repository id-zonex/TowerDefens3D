using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITowerControler : MonoBehaviour
{
    [SerializeField] private GameObject _towerUIWindow;

    [SerializeField] private Text _nameText;
    [SerializeField] private LayerMask _layerMask;

    private Tower _currentTower;

    private void Update()
    {
        //if (CamersControler.CurrentCameraType == CamersControler.CamersTyps.TopDownCamera)
        //{
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = CamersControler.MainCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, _layerMask))
                {
                    OpenTowerUIWindow();

                    Tower tower = hit.collider.gameObject.GetComponentInParent<Tower>();

                    if (tower != null)
                    {
                        SetTowerUI(tower);
                    }
                    else if(!EventSystem.current.IsPointerOverGameObject())
                    {
                        CloseTowerUIWindow();
                    }
                }
            }
        //}
    }

    private void CloseTowerUIWindow()
    {
        _towerUIWindow.SetActive(false);
    }

    private void OpenTowerUIWindow()
    {
        _towerUIWindow.SetActive(true);
    }

    private void SetTowerUI(Tower tower)
    {
        _currentTower = tower;

        _nameText.text = tower.name;
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
