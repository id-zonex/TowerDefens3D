using UnityEngine;

[RequireComponent(typeof(FirstPlayerMover))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private FirstPlayerMover _firstPlayerMover;
    [SerializeField] private TopDownCameraMover _topDownCameraMover;

    [SerializeField] private CamersControler.CameraType _firstCamera;
    [SerializeField] private CamersControler.CameraType _topDownCamera;

    private bool IsPressed = false;

    private void Start()
    {
        CamersControler.SetCamera(_firstCamera);
        _firstPlayerMover = GetComponent<FirstPlayerMover>();
    }

    private void Update()
    {
        TryChangeCamera();

        if (CamersControler.currentCamera.cameraType == CamersControler.CamersTyps.TopDownCamera)
            _topDownCameraMover.ControleOnlyInUpdate();
        else
            _firstPlayerMover.ControleOnlyInUpdate();

    }

    private void FixedUpdate()
    {
        if (CamersControler.currentCamera.cameraType == CamersControler.CamersTyps.FirstCamera)
            _firstPlayerMover.ControleOnlyInFixedUpdate();      
    }

    private void TryChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            IsPressed = !IsPressed;

        if (IsPressed)
            ChangeCamera(_firstCamera);
        else
            ChangeCamera(_topDownCamera);
    }

    private void ChangeCamera(CamersControler.CameraType camera)
    {
        _firstCamera.mainCamera.gameObject.SetActive(false);
        _topDownCamera.mainCamera.gameObject.SetActive(false);

        camera.mainCamera.gameObject.SetActive(true);

        CamersControler.SetCamera(camera);
    }
}
