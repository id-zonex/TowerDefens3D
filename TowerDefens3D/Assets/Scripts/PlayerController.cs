using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FirstPlayerMover))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private FirstPlayerMover _firstPlayerMover;
    [SerializeField] private TopDownCameraMover _topDownCameraMover;

    [SerializeField] private Camera _firstCamera;
    [SerializeField] private Camera _topDownCamera;

    private bool IsPressed = false;


    private void Awake()
    {
        _firstPlayerMover = GetComponent<FirstPlayerMover>();
    }

    private void Update()
    {
        TryChangeCamera();

        _firstPlayerMover.Rotate();
    }

    private void FixedUpdate()
    {
        _firstPlayerMover.Move();
    }

    private void TryChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IsPressed = !IsPressed;
        }

        if (IsPressed)
        {
            _firstCamera.gameObject.SetActive(!_firstCamera.enabled);
            _topDownCamera.gameObject.SetActive(_topDownCamera.enabled);
            CamersControler.SetCamera(_topDownCamera, CamersControler.CamersTyps.TopDownCamera);
        }
        else
        {
            _firstCamera.gameObject.SetActive(_firstCamera.enabled);
            _topDownCamera.gameObject.SetActive(!_topDownCamera.enabled);
            CamersControler.SetCamera(_firstCamera, CamersControler.CamersTyps.FirstCamera);
        }
    }
}
