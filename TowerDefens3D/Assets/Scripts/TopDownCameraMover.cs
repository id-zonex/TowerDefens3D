using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TopDownCameraMover : PlayerMover
{
    [SerializeField] private float _magnificationFactor = 1;

    [SerializeField] private float _speed;
 
    [SerializeField] private float _maxSize;
    [SerializeField] private float _minSize;

    [SerializeField] private Vector3 _minPos;
    [SerializeField] private Vector3 _maxPos;

    private Vector3 _verticalStartPos;
    private Vector3 _horizontalStartPos;

    private float _verticalTargetPos;
    private float _horizontalTargetPos;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    protected override void ControleFixedUpdate()
    {
        HorizontalMove();
        VerticalMove();
    }

    protected override void ControleUpdate()
    {
        Scale();
    }

    private void Scale()
    {
        Camera camera = CamersControler.currentCamera.mainCamera;

        float scroll = Input.mouseScrollDelta.y * _magnificationFactor;
        camera.orthographicSize += scroll;

        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, _minSize, _maxSize);
    }

    private void HorizontalMove()
    {
        if (Input.GetMouseButtonDown(0)) _horizontalStartPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float position = _camera.ScreenToWorldPoint(Input.mousePosition).x - _horizontalStartPos.x;
            _horizontalTargetPos = Mathf.Clamp(transform.position.x - position, _minPos.x, _maxPos.x);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x - position, _minPos.x, _maxPos.x), transform.position.y, transform.position.z);
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, _horizontalTargetPos, _speed * Time.fixedDeltaTime), transform.position.y, transform.position.z);
    }

    private void VerticalMove()
    {
        if (Input.GetMouseButtonDown(0)) _verticalStartPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float position = _camera.ScreenToWorldPoint(Input.mousePosition).z - _verticalStartPos.z;
            _verticalTargetPos = Mathf.Clamp(transform.position.z - position, _minPos.y, _maxPos.y);
            //transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z - position, _minPos.y, _maxPos.y));
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, _verticalTargetPos, _speed * Time.fixedDeltaTime));
    }
}
