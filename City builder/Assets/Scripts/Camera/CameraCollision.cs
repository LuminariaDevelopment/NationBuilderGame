using CameraControl;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraCollision : MonoBehaviour
{
    Transform _cameraTransform;
    CameraMotion _camMotion;

    [SerializeField] LayerMask _layerMask;
    [SerializeField] LayerMask _inverseLayerMask;

    private void Start()
    {
        _camMotion = FindAnyObjectByType<CameraMotion>();
        _cameraTransform = GameObject.Find("Main Camera").transform;
    }

    private void Update()
    {
        CalculateHight();
    }

    void CalculateHight()
    {
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(_cameraTransform.position.x, _cameraTransform.transform.position.y + 10000, _cameraTransform.position.z), Vector3.down, out hit, Mathf.Infinity, _inverseLayerMask))
        {
            _camMotion._targetPosition.y = hit.point.y + 1;
        }
        else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 10000, transform.position.z), Vector3.down, out hit, Mathf.Infinity, _layerMask))
        {
            _camMotion._targetPosition.y = hit.point.y + 1;
        }
    }
}
