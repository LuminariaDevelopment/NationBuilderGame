using CameraControl;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [SerializeField]float _rayDist;

    Transform _cameraTransform;
    CameraMotion _camMotion;

    private void Start()
    {
        _camMotion = FindAnyObjectByType<CameraMotion>();
        _cameraTransform = GameObject.Find("Main Camera").transform;
        CameraGravity();
    }

    void CameraGravity()
    {
        bool _rayForward = Physics.Raycast(_cameraTransform.position, Vector3.forward, _rayDist);
        bool _rayBackward = Physics.Raycast(_cameraTransform.position, Vector3.back, _rayDist);
        bool _rayRight = Physics.Raycast(_cameraTransform.position, Vector3.right, _rayDist);
        bool _rayLeft = Physics.Raycast(_cameraTransform.position, Vector3.left, _rayDist);

        if (!Physics.Raycast(transform.position, Vector3.down, _rayDist))
        {
            if (!Physics.Raycast(_cameraTransform.position, Vector3.down, _rayDist))
            {
                _camMotion._targetPosition.y -= 1;
            }
        }

        if (_rayForward || _rayBackward || _rayLeft || _rayRight)
        {
            _camMotion._targetPosition.y += 1;
        }

        Invoke("CameraGravity", 0.1f);
    }

}
