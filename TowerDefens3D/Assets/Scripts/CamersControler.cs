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

    public static CameraType currentCamera { get; private set; }

    public static void SetCamera(CameraType camera)
    {
        currentCamera = camera;
    }

    [System.Serializable]
    public struct CameraType
    {
        public Camera mainCamera;
        public CamersTyps cameraType;
    }
}
