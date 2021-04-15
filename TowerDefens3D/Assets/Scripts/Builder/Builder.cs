using UnityEngine;


public class Builder : MonoBehaviour
{
    private static Tower _testTowerPrefab;

    private static GameObject _greenTowerPrefab;

    private static GameObject _tower;

    private static Ray GetRayFromMousePos => CamersControler.currentCamera.mainCamera.ScreenPointToRay(Input.mousePosition);
    

    private void Update()
    {
        if (CamersControler.currentCamera.cameraType == CamersControler.CamersTyps.TopDownCamera)
        {
            if (Input.GetMouseButton(1) && _tower != null)
            {
                MoveGreenTower();

                PlugTowerSetMeterial();
            }

            if (Input.GetKeyDown(KeyCode.Z) && _tower != null)
                BuildCurrentTower();
            if (Input.GetKeyDown(KeyCode.X))
                DestroyGreenTower();
        }

    }

    public static void BuildTower(Tower tower, GameObject templateTower)
    {
        SetCurrentTower(tower, templateTower);

        BuildTowerTemplate();

        MoveGreenTower();
    }


    #region Tower Template
    private static void BuildTowerTemplate()
    {
        if (_tower == null)
        {
            _tower = Instantiate(_greenTowerPrefab);
        }
    }

    private static void MoveGreenTower()
    {
        Ray ray = GetRayFromMousePos;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _tower.transform.position = GridSystem.GetPointOnGrid(new Vector3(hit.point.x, 0, hit.point.z));
        }
    }

    private static void DestroyGreenTower()
    {
        Destroy(_tower);
    }

    private static void PlugTowerSetMeterial()
    {
        if (CheckCollision(Physics.OverlapSphere(_tower.transform.position, 0.5f)))
            _tower.GetComponent<TowerPlug>().SetGreenMaterial();
        else
            _tower.GetComponent<TowerPlug>().SetRedMaterial();
    }
    #endregion


    private static void SetCurrentTower(Tower tower, GameObject templateTower)
    {
        _testTowerPrefab = tower;
        _greenTowerPrefab = templateTower;
    }

    private static void BuildCurrentTower()
    {
        if (!(CheckCollision(Physics.OverlapSphere(_tower.transform.position, 0.5f))))
        {
            DestroyGreenTower();
            return;
        }

        bool isBuy = Money.SubtractMoney(_testTowerPrefab.TowerData.price);
        if(isBuy)
            Instantiate(_testTowerPrefab, _tower.transform.position, Quaternion.identity);

        DestroyGreenTower();
    }

    private static bool CheckCollision(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];

            switch (collider.gameObject.tag)
            {
                case "tower":
                    return false;
                case "Decorations":
                    return false;
                case "Path":
                    return false;
            }
        }
        return true;
    }
}
