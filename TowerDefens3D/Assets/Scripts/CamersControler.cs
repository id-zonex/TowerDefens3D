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

    public static Camera MainCamera { get; private set; }
    public static CamersTyps CurrentCameraType { get; protected set; } = CamersTyps.FirstCamera;

    public static void SetCamera(Camera camera, CamersTyps cameraType)
    {
        MainCamera = camera;
        CurrentCameraType = cameraType;
    }
}
