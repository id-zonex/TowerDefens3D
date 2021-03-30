using UnityEngine;


public class Builder : MonoBehaviour
{
    [SerializeField] private Tower _testTowerPrefab;
    [SerializeField] private GameObject _greenTowerPrefab;

    [SerializeField] private LayerMask _layerMask;

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
            if (Input.GetMouseButtonDown(2))
            {
                BuildGreenTower();
            }

            if (Input.GetMouseButtonUp(2))
            {
                BuildTower();
            }
        }

    }

    private void BuildGreenTower()
    {
        _tower = Instantiate(_greenTowerPrefab);

        Ray ray = GetRayFromMousePos;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _tower.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
        }       
    }

    private void BuildTower()
    {
        if (CheckCollision(Physics.OverlapSphere(_tower.transform.position, 0.5f)))
            Instantiate(_testTowerPrefab, _tower.transform.position, Quaternion.identity);
        Destroy(_tower);
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
