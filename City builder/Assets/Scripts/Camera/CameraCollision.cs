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
    public LayerMask _inverseLayermask;

    private void Start()
    {
        _camMotion = FindAnyObjectByType<CameraMotion>();
        _cameraTransform = GameObject.Find("Main Camera").transform;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(_cameraTransform.position.x, _cameraTransform.transform.position.y + 10000, _cameraTransform.position.z), Vector3.down, out hit, Mathf.Infinity, _inverseLayermask))
        {
            _camMotion._targetPosition.y = hit.point.y + 1;
        }
        else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 10000, transform.position.z), Vector3.down, out hit, Mathf.Infinity, _layerMask))
        {
                _camMotion._targetPosition.y = hit.point.y + 1;
        }
    }

}
