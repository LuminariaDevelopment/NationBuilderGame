using CameraControl;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraCollision : MonoBehaviour
{
    [SerializeField]int _rayDist;

    Transform _cameraTransform;
    CameraMotion _camMotion;

    public LayerMask _layerMask;

    private void Start()
    {
        _camMotion = FindAnyObjectByType<CameraMotion>();
        _cameraTransform = GameObject.Find("Main Camera").transform;
        CameraGravity();
    }

    private void Update()
    {
        RaycastHit hit1;
        RaycastHit hit2;

        if (Physics.Raycast(transform.position, Vector3.down, out hit1, Mathf.Infinity, _layerMask))
        {
            _camMotion._targetPosition.y = hit1.point.y + 1;
        }
        if (Physics.Raycast(transform.position, Vector3.up, out hit2, Mathf.Infinity, _layerMask))
        {
            _camMotion._targetPosition.y = hit2.point.y + 1;
        }
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


        Invoke("CameraGravity", 0.15f);
    }

}
