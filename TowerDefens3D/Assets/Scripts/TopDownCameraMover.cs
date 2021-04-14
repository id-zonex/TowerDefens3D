using UnityEngine;

public class TopDownCameraMover : PlayerMover
{
    [SerializeField] private float magnificationFactor = 1;

    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;

    protected override void ControleFixedUpdate()
    {
        return;
    }

    protected override void ControleUpdate()
    {
        Scale();
    }

    private void Scale()
    {
        Camera camera = CamersControler.currentCamera.mainCamera;

        float scroll = Input.mouseScrollDelta.y * magnificationFactor;
        camera.orthographicSize += scroll;

        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minSize, maxSize);
    }
}
