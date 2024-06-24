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
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 10000, transform.position.z), Vector3.down, out hit, Mathf.Infinity, _layerMask))
        {
                _camMotion._targetPosition.y = hit.point.y + 1;
                Debug.Log("HIT!");
        }

    }

}
