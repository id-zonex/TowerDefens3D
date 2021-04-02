using UnityEngine;


public class Builder : MonoBehaviour
{
    [SerializeField] private Tower _testTowerPrefab;

    [SerializeField] private GameObject _greenTowerPrefab;

    private Camera _camera;

    private GameObject _tower;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private Ray GetRayFromMousePos => CamersControler.MainCamera.ScreenPointToRay(Input.mousePosition);
    
    private void Update()
    {
        if (CamersControler.CurrentCameraType == CamersControler.CamersTyps.TopDownCamera)
        {
            if(Input.GetMouseButtonDown(1) && _tower == null)
            {
                _tower = Instantiate(_greenTowerPrefab);
            }

            if (Input.GetMouseButton(1) && _tower != null)
            {
                MoveGreenTower();

                PlugTowerControleMeterial();
            }

            if (Input.GetKeyDown(KeyCode.Z) && _tower != null)
                BuildTower();
            if (Input.GetKeyDown(KeyCode.X))
                DestroyGreenTower();
        }

    }

    private void MoveGreenTower()
    {
        Ray ray = GetRayFromMousePos;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _tower.transform.position = GridSystem.GetPointOnGrid(new Vector3(hit.point.x, 0, hit.point.z));
        }       
    }

    private void BuildTower()
    {
        if (CheckCollision(Physics.OverlapSphere(_tower.transform.position, 0.5f)))
            Instantiate(_testTowerPrefab, _tower.transform.position, Quaternion.identity);
        DestroyGreenTower();
    }

    private void DestroyGreenTower()
    {
        Destroy(_tower);
    }

    private void PlugTowerControleMeterial()
    {
        if (CheckCollision(Physics.OverlapSphere(_tower.transform.position, 0.5f)))
            _tower.GetComponent<TowerPlug>().SetGreenMaterial();
        else
            _tower.GetComponent<TowerPlug>().SetRedMaterial();
    }

    private bool CheckCollision(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];

            switch (collider.gameObject.tag)
            {
                case "tower":
                    return false;
                    break;
                case "Decorations":
                    return false;
                    break;
                case "Path":
                    print("path");
                    return false;
                    break;
            }
        }
        return true;
    }
}
