using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamersControler : MonoBehaviour
{
    public enum CamersTyps
    {
        FirstCamera,
        TopDownCamera
    }

    public static Camera MainCamera { get { return _mainCamera; } }
    public static CamersTyps CurrentCameraType { get { return _currentCameraType;  } }

    private static Camera _mainCamera;

    private static CamersTyps _currentCameraType = CamersTyps.FirstCamera;

    public static void SetCamera(Camera camera, CamersTyps cameraType)
    {
        _mainCamera = camera;
        _currentCameraType = cameraType;
    }
}
